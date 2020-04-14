using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace Weibo
{
    public partial class Form1 : Form
    {
        List<Pic> listImage = new List<Pic>();
        List<Media_Info> listVideo = new List<Media_Info>();
        string path ="";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            listImage.Clear();
            listVideo.Clear();
            if(!checkBox1.Checked && !checkBox2.Checked)
            {
                MessageBox.Show("Hãy chọn 1 phương thức để lưu");
                return;
            }
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath+"\\";
            }
            else
            {
                return;
            }
            Thread t = new Thread(
                ()=> {
                    setDataOnThread(lbStatus, "Đang lấy link ảnh...");
                    getList(tbUID.Text);
                    
                    if (checkBox1.Checked)
                    {
                        setDataOnThread(lbStatus, "Đang Lưu file txt");
                        DateTime now = DateTime.Now;
                        string format = "dd_MM_yyyy HH_mm_ss";
                        string s = now.ToString(format);
                        foreach (Pic item in listImage)
                        {
                            try
                            {
                                File.AppendAllText(path + s + " Image.txt", item.large.url+"\n");
                            }
                            catch (Exception ex)
                            {
                                File.WriteAllText(path + s + " Image.txt", ex.Message + "\n");
                            }

                        }
                        foreach (Media_Info item in listVideo)
                        {
                            try
                            {
                                File.AppendAllText(path + s + " Video.txt", item.mp4_hd_url+"\n");
                            }
                            catch (Exception ex)
                            {
                                File.WriteAllText(path + s + " Video.txt", ex.Message+"\n");
                            }


                        }

                        setDataOnThread(lbStatus, "Đang Lưu file txt thành công");
                        Process.Start(path);
                    }
                    
                    if (checkBox2.Checked)
                    {
                        setDataOnThread(lbStatus, "Đang Lưu file ảnh");
                        download();
                        setDataOnThread(lbStatus, "Đang Lưu file ảnh xong");
                        Process.Start(path);
                        setDataOnThread(lbStatus, "");
                    }
                });
            t.IsBackground = true;
            t.Start();

        }
        public static void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        public void getList(String uid)
        {
            int posision = 0;
            int count =0;
            HttpRequest http = new HttpRequest();
            int ok = 1;
            while (ok==1)
            {
                string url = "https://m.weibo.cn/api/container/getIndex?type=uid&value="+uid+"&containerid=107603"+uid+"&page="+posision;
                try
                {
                    setDataOnThread(richTextBox1, "Gửi Request");
                    string resulf = http.Get(url).ToString();
                    Rootobject root = JsonConvert.DeserializeObject<Rootobject>(resulf);
                    if (root.ok != 1)
                    {
                        setDataOnThread(richTextBox1, "Đã hoàn thành");
                        return;
                    }
                    setDataOnThread(lbCount, root.data.cardlistInfo.total+"");
                    foreach (Card item in root.data.cards)
                    {
                        if(item.card_type == 9)
                        {
                            if(item.mblog.page_info != null)
                            {
                                if(item.mblog.page_info.media_info != null)
                                {
                                    listVideo.Add(item.mblog.page_info.media_info);
                                    count++;
                                    setDataOnThread(lbPics, count + "");
                                    setDataOnThread(richTextBox1, "Lưu video: "+item.mblog.page_info.media_info.h265_mp4_hd);
                                }
                            }
                            if (item.mblog.pics != null)
                            {
                                foreach(Pic pics in item.mblog.pics)
                                {
                                    listImage.Add(pics);
                                    count++;
                                    setDataOnThread(lbPics, count + "");
                                    setDataOnThread(richTextBox1,"Lưu ảnh: "+pics.url);
                                }
                                    
                            }
                            posision++;
                            setDataOnThread(lbCountOK, posision + "");
                        }
                        setDataOnThread(richTextBox1, "Xong requets");
                        
                    }
                    ok = root.ok;
                }
                catch(Exception ex)
                {
                    ok = 0;
                }
                Thread.Sleep(new Random().Next(1000,3000));
            }
            
        }
        
        public void setDataOnThread(Control control, string text,Color color)
        {
            control.Invoke(new MethodInvoker(
                () =>
                {
                    if(control is RichTextBox)
                    {
                        RichTextBox ric = (RichTextBox)control;
                        AppendText(ric,text + "\n", color);
                    }
                    else
                    {
                        control.Text = text;
                    }

                }
                ));
        }
        public void setDataOnThread(Control control, string text)
        {
            control.Invoke(new MethodInvoker(
                () =>
                {
                    if (control is RichTextBox)
                    {
                        RichTextBox ric = (RichTextBox)control;
                        ric.AppendText(text + "\n");
                    }
                    else
                    {
                        control.Text = text;
                    }

                }
                ));
        }
        
        public void download()
        {
            int image = 0;
            int video = 0;
            int error =0;

            foreach(Pic item in listImage)
            {
                DateTime date = DateTime.Now;
                String name = date.Ticks + "_" + image+".jpg";
                try
                {
                    HttpRequest http = new HttpRequest();
                    http.Get(item.large.url).ToFile(path+name);
                    image++;
                    setDataOnThread(lbImageOK, image + "");
                }catch(Exception ex)
                {
                    File.AppendAllText(path + "error.txt", item.large.url+"\n");
                    error++;
                    setDataOnThread(lbError, error + "");
                }
                
            }
            foreach(Media_Info item in listVideo)
            {
                DateTime date = DateTime.Now;
                String name = date.Ticks + "_" + video + ".mp4";
                try
                {
                    HttpRequest http = new HttpRequest();
                    http.Get(item.mp4_hd_url).ToFile(path + name);
                    video++;
                    setDataOnThread(lbVideoOK, video + "");
                }
                catch (Exception ex)
                {
                    File.AppendAllText(path + "error.txt", item.mp4_hd_url + "\n");
                    error++;
                    setDataOnThread(lbError, error + "");
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    class DataWeibo
    {
        List<Large> listImage ;
        List<Media_Info> listVideo;
        public DataWeibo(List<Large> listImage, List<Media_Info> listVideo)
        {
            this.listImage = listImage;
            this.listVideo = listVideo;
        }
    }

    public class Rootobject
    {
        public int ok { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Cardlistinfo cardlistInfo { get; set; }
        public Card[] cards { get; set; }
        public object banners { get; set; }
        public string scheme { get; set; }
    }

    public class Cardlistinfo
    {
        public string containerid { get; set; }
        public int v_p { get; set; }
        public int show_style { get; set; }
        public int total { get; set; }
        public long since_id { get; set; }
    }

    public class Card
    {
        public int card_type { get; set; }
        public int card_style { get; set; }
        public int display_arrow { get; set; }
        public bool skip_group_title { get; set; }
        public Card_Group[] card_group { get; set; }
        public string itemid { get; set; }
        public string scheme { get; set; }
        public Mblog mblog { get; set; }
        public int show_type { get; set; }
    }

    public class Mblog
    {
        public Visible visible { get; set; }
        public string created_at { get; set; }
        public string id { get; set; }
        public string idstr { get; set; }
        public string mid { get; set; }
        public bool can_edit { get; set; }
        public int version { get; set; }
        public int show_additional_indication { get; set; }
        public string text { get; set; }
        public int textLength { get; set; }
        public string source { get; set; }
        public bool favorited { get; set; }
        public string pic_types { get; set; }
        public string thumbnail_pic { get; set; }
        public string bmiddle_pic { get; set; }
        public string original_pic { get; set; }
        public bool is_paid { get; set; }
        public int mblog_vip_type { get; set; }
        public User user { get; set; }
        public string picStatus { get; set; }
        public int reposts_count { get; set; }
        public int comments_count { get; set; }
        public int attitudes_count { get; set; }
        public int pending_approval_count { get; set; }
        public bool isLongText { get; set; }
        public int reward_exhibition_type { get; set; }
        public int hide_flag { get; set; }
        public int mlevel { get; set; }
        public string topic_id { get; set; }
        public bool sync_mblog { get; set; }
        public bool is_imported_topic { get; set; }
        public int ad_state { get; set; }
        public int mblogtype { get; set; }
        public int more_info_type { get; set; }
        public string cardid { get; set; }
        public int extern_safe { get; set; }
        public int content_auth { get; set; }
        public int pic_num { get; set; }
        public int mblog_menu_new_style { get; set; }
        public Edit_Config edit_config { get; set; }
        public int isTop { get; set; }
        public int weibo_position { get; set; }
        public int show_attitude_bar { get; set; }
        public Page_Info page_info { get; set; }
        public Product_Struct[] product_struct { get; set; }
        public string bid { get; set; }
        public Pic[] pics { get; set; }
        public Title title { get; set; }
        public Number_Display_Strategy number_display_strategy { get; set; }
        public int edit_count { get; set; }
        public string edit_at { get; set; }
        public string obj_ext { get; set; }
        public int safe_tags { get; set; }
        public Retweeted_Status retweeted_status { get; set; }
        public int repost_type { get; set; }
        public string raw_text { get; set; }
    }

    public class Visible
    {
        public int type { get; set; }
        public int list_id { get; set; }
    }

    public class User
    {
        public long id { get; set; }
        public string screen_name { get; set; }
        public string profile_image_url { get; set; }
        public string profile_url { get; set; }
        public int statuses_count { get; set; }
        public bool verified { get; set; }
        public int verified_type { get; set; }
        public bool close_blue_v { get; set; }
        public string description { get; set; }
        public string gender { get; set; }
        public int mbtype { get; set; }
        public int urank { get; set; }
        public int mbrank { get; set; }
        public bool follow_me { get; set; }
        public bool following { get; set; }
        public int followers_count { get; set; }
        public int follow_count { get; set; }
        public string cover_image_phone { get; set; }
        public string avatar_hd { get; set; }
        public bool like { get; set; }
        public bool like_me { get; set; }
        public Badge badge { get; set; }
    }

    public class Badge
    {
        public int unread_pool { get; set; }
        public int unread_pool_ext { get; set; }
        public int dzwbqlx_2016 { get; set; }
        public int user_name_certificate { get; set; }
        public int wenda_v2 { get; set; }
        public int suishoupai_2019 { get; set; }
        public int hongrenjie_2019 { get; set; }
        public int china_2019 { get; set; }
        public int dzwbqlx_2019 { get; set; }
        public int hongbao_2020 { get; set; }
    }

    public class Edit_Config
    {
        public bool edited { get; set; }
        public Menu_Edit_History menu_edit_history { get; set; }
    }

    public class Menu_Edit_History
    {
        public string scheme { get; set; }
        public string title { get; set; }
    }

    public class Page_Info
    {
        public Page_Pic page_pic { get; set; }
        public string page_url { get; set; }
        public string page_title { get; set; }
        public string content1 { get; set; }
        public string content2 { get; set; }
        public string type { get; set; }
        public string object_id { get; set; }
        public Media_Info media_info { get; set; }
        public int play_count { get; set; }
    }

    public class Page_Pic
    {
        public string url { get; set; }
    }

    public class Media_Info
    {
        public string video_orientation { get; set; }
        public string name { get; set; }
        public string stream_url { get; set; }
        public string stream_url_hd { get; set; }
        public string h5_url { get; set; }
        public string mp4_sd_url { get; set; }
        public string mp4_hd_url { get; set; }
        public string h265_mp4_hd { get; set; }
        public string h265_mp4_ld { get; set; }
        public string inch_4_mp4_hd { get; set; }
        public string inch_5_mp4_hd { get; set; }
        public string inch_5_5_mp4_hd { get; set; }
        public string mp4_720p_mp4 { get; set; }
        public string hevc_mp4_720p { get; set; }
        public int prefetch_type { get; set; }
        public int prefetch_size { get; set; }
        public int act_status { get; set; }
        public string protocol { get; set; }
        public string media_id { get; set; }
        public int origin_total_bitrate { get; set; }
        public int duration { get; set; }
        public string next_title { get; set; }
        public Play_Completion_Actions[] play_completion_actions { get; set; }
        public int video_publish_time { get; set; }
        public int play_loop_type { get; set; }
        public string author_mid { get; set; }
        public string author_name { get; set; }
        public Extra_Info extra_info { get; set; }
        public int has_recommend_video { get; set; }
        public Video_Download_Strategy video_download_strategy { get; set; }
        public int jump_to { get; set; }
        public string online_users { get; set; }
        public int online_users_number { get; set; }
        public int ttl { get; set; }
        public string storage_type { get; set; }
        public int is_keep_current_mblog { get; set; }
    }

    public class Extra_Info
    {
        public string sceneid { get; set; }
    }

    public class Video_Download_Strategy
    {
        public int abandon_download { get; set; }
    }

    public class Play_Completion_Actions
    {
        public string type { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public string link { get; set; }
        public int btn_code { get; set; }
        public int show_position { get; set; }
        public Actionlog actionlog { get; set; }
    }

    public class Actionlog
    {
        public string oid { get; set; }
        public int act_code { get; set; }
        public int act_type { get; set; }
        public string source { get; set; }
    }

    public class Title
    {
        public string text { get; set; }
        public int base_color { get; set; }
    }

    public class Number_Display_Strategy
    {
        public int apply_scenario_flag { get; set; }
        public int display_text_min_number { get; set; }
        public string display_text { get; set; }
    }

    public class Retweeted_Status
    {
        public Visible1 visible { get; set; }
        public string created_at { get; set; }
        public string id { get; set; }
        public string idstr { get; set; }
        public string mid { get; set; }
        public string text { get; set; }
        public int state { get; set; }
        public string deleted { get; set; }
        public Edit_Config1 edit_config { get; set; }
        public int weibo_position { get; set; }
        public int show_attitude_bar { get; set; }
        public int retweeted { get; set; }
        public object user { get; set; }
        public string bid { get; set; }
        public string source { get; set; }
    }

    public class Visible1
    {
        public int type { get; set; }
        public int list_id { get; set; }
    }

    public class Edit_Config1
    {
        public bool edited { get; set; }
    }

    public class Product_Struct
    {
        public string url { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public string page_id { get; set; }
        public Actionlog1 actionlog { get; set; }
        public Button[] buttons { get; set; }
    }

    public class Actionlog1
    {
        public string act_code { get; set; }
        public long uid { get; set; }
        public long mid { get; set; }
        public string oid { get; set; }
        public string uicode { get; set; }
        public string cardid { get; set; }
        public string fid { get; set; }
        public string luicode { get; set; }
        public string lfid { get; set; }
        public string ext { get; set; }
        public string source { get; set; }
    }

    public class Button
    {
        public string name { get; set; }
        public string pic { get; set; }
        public string type { get; set; }
        public Params _params { get; set; }
        public int sub_type { get; set; }
        public Actionlog2 actionlog { get; set; }
    }

    public class Params
    {
        public string uid { get; set; }
        public string scheme { get; set; }
        public string type { get; set; }
    }

    public class Actionlog2
    {
        public int act_code { get; set; }
        public long uid { get; set; }
        public long mid { get; set; }
        public string oid { get; set; }
        public string uicode { get; set; }
        public string cardid { get; set; }
        public string fid { get; set; }
        public string luicode { get; set; }
        public string lfid { get; set; }
        public string ext { get; set; }
        public string source { get; set; }
    }

    public class Pic
    {
        public string pid { get; set; }
        public string url { get; set; }
        public string size { get; set; }
        public Geo geo { get; set; }
        public Large large { get; set; }
    }

    public class Geo
    {
        public int width { get; set; }
        public int height { get; set; }
        public bool croped { get; set; }
    }

    public class Large
    {
        public string size { get; set; }
        public string url { get; set; }
        public Geo1 geo { get; set; }
    }

    public class Geo1
    {
        public object width { get; set; }
        public object height { get; set; }
        public bool croped { get; set; }
    }

    public class Card_Group
    {
        public int card_type { get; set; }
        public int col { get; set; }
        public Group[] group { get; set; }
    }

    public class Group
    {
        public string title_sub { get; set; }
        public string word_scheme { get; set; }
        public string scheme { get; set; }
        public Action_Log action_log { get; set; }
        public string icon { get; set; }
    }

    public class Action_Log
    {
        public int act_code { get; set; }
        public string oid { get; set; }
        public string ext { get; set; }
        public string fid { get; set; }
    }

}
