using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;
using System.Globalization;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

using Newtonsoft.Json;

using DiscordRPC;



namespace Otogexe
{




    public partial class Otog : Form
    {

        public const int MAX_TESTCASE = 300;

        public List<string> Ava_Lang = new List<string> { "C", "C++", "Python", "Java" };
        public Dictionary<string, string> File_Type = new Dictionary<string, string>() {
            {"C","C source code|*.c;*.i"},
            {"C++","C++ source code|*.cpp;*.cc;*.cxx;*.c++;*.hpp;*.hh;*.hxx;*.h++;*.h;*.ii;"},
            {"Python","Python source code|*.py;*.rpy;*.pyw;*.cpy;*.gyp;*.gypi;*.pyi;*.ipy;"},
            {"Java","Java source code|*.java;*.jav;"}
        };

        public List<Dictionary<string, string>> G_Lang = new List<Dictionary<string, string>>()
        {
           new Dictionary<string,string>{{"Call_Lang","English"},{"Check Update","Check Update"},{"CUNet","Can't Connect \n\n :("},{"CUUp","It's Up to date\n\n Yey!"},{"CUNup","There are new Update"},{"Task","Task"},{"Lang","Lang"},{"Time","Time"},{"Mem","Mem"},{"Doc","Doc"},{"Browse","Browse"},{"SUPMIT!","SUBMIT!"},{"TEST!","TEST!"},{"TestMode","Test Mode"},{"Help","Help!"},{"More Task","More Task"},{"S1","Select Task"},{"S0","Ready!"},{"S2","Select file"},{"S3","Compile..."},{"S4","Judging..."},{"S5","Testing..."},{"S-1","Select Group"},{"SERR","ERROR!"},{"Start Clock","Start Clock"},{"Stop Clock","Stop Clock"},{"Reset Clock","Reset Clock"},{"File","File"},{"Result","Result"},{"Point","Score"},{"Show Comment","Show Comment"},{"Input","Input"},{"Output","Output"},{"JP","Accept"},{"JT","Time Limit Exceed"},{"JX","Runtime Error"},{"J-","Wrong Answer"},{"JS","Skiped"},{"JH","Partially Correct"},{"JC","Compile Error"},{"J!","JudgeError!"},{"Jc","Complete"},{"J?","Undefined!"},},
           new Dictionary<string,string>{{"Call_Lang","ภาษาไทย"},{"Check Update","ตรวจอัพเกรด"},{"CUNet","ไม่สามารถเชื่อมต่อ \n\n :("},{"CUUp","เป็นเวอร์ชั่นปัจจุบันแล้ว\n\n สวยพี่สวย!"},{"CUNup","มีอัพเดธใหม่"},{"Task","ข้อ"},{"Lang","ภาษา"},{"Time","เวลา"},{"Mem","ความจำ"},{"Doc","โจทย์"},{"Browse","เลือกไฟล์"},{"SUPMIT!","ส่ง!"},{"TEST!","ทดสอบ!"},{"TestMode","โหมดทดสอบ"},{"Help","ช่วยเหลือ"},{"More Task","โจทย์ใหม่"},{"S1","กรุณาเลือกโจทย์"},{"S0","พร้อม!"},{"S2","กรุณาเลือกไฟล์"},{"S3","กำลังคอมไพล์..."},{"S4","กำลังตรวจ..."},{"S5","กำลังทดสอบ..."},{"S-1","กรุณาเลือกกลุ่มโจทย์"},{"SERR","ERROR!"},{"Start Clock","เริ่มจับเวลา"},{"Stop Clock","หยุดเวลา"},{"Reset Clock","รีเซ็ตเวลา"},{"File","ไฟล์"},{"Result","ผลการตรวจ"},{"Point","คะแนน"},{"Show Comment","แสดงคอมเม้น"},{"Input","ข้อมูลนำเข้า"},{"Output","ข้อมูลส่งออก"},{"JP","ผ่าน"},{"JT","เวลาเกินกำหนด"},{"JX","โปรแกรมเกิดระเบิด"},{"J-","คำตอบไม่ถูกต้อง"},{"JS","ข้าม"},{"JH","ได้คะแนนในบางส่วน"},{"JC","คอมไพล์เออเร่อ"},{"J!","ตัวตรวจผิดพลาด!"},{"Jc","เสร็จสิ้น"},{"J?","ไม่สามารถระบุได้!"},},
           new Dictionary<string,string>{{"Call_Lang","พาศาทัย"},{"Check Update","ตลวจอัปเกลด"},{"CUNet","มั่ยมีย์แณ็ตแร้วจะดูย์หยังงัย \n\n สึส"},{"CUUp","มั่ยต่องอับหลอก\n\n โต๊แร้ว!"},{"CUNup","ไปอัพพพพพพพพ"},{"Task","ค่อ"},{"Lang","พาศา"},{"Time","เพลา"},{"Mem","คามจัม"},{"Doc","จด"},{"Browse","เริอกไฟ"},{"SUPMIT!","ศ่ง!"},{"TEST!","ธดซอบ!"},{"TestMode","โมดธดซอบ"},{"S1","รุกณาเรือกจด"},{"S0","พร้อม!"},{"S2","รุกณาเรือกไฟ"},{"S3","กำลังไฟฟ้า..."},{"S4","กำลังดู..."},{"S5","กำลังทำอะไรไม่รู่..."},{"S-1","รุกณาเรือกกุ่ลมโจ"},{"SERR","ERROR!"},{"Help","เหมียว"},{"More Task","จดมั่ย"},{"Start Clock","เริ่มเพลา"},{"Stop Clock","หยุดเพลา"},{"Reset Clock","รีเพลา"},{"File","ไฟ"},{"Result","โพล"},{"Point","ฅ๊ะแน็ต"},{"Show Comment","แส-ดงคอมโปร"},{"Input","เข้าๆ"},{"Output","ออกๆ"},{"JP","ทุก"},{"JT","ช้าาาาาาา"},{"JX","กาก"},{"J-","ผิด"},{"JS","ไม่ตรวจ หยิ่ง"},{"JH","เกือบถูก"},{"JC","กากสัสๆ"},{"J!","กูผิดเอง!"},{"Jc","สา่ิร่พนิื"},{"J?","ไม่บอก!"},},
           new Dictionary<string,string>{{"Call_Lang","ภาษาแมว"},{"Check Update","เหมียว"},{"CUNet","เหมียวเน็ต"},{"CUUp","เหมียวเย่"},{"CUNup","เหมียวโน"},{"Task","เหมียว"},{"Lang","เหมียว"},{"Time","เหมียว"},{"Mem","เหมียว"},{"Doc","เหมียว"},{"Browse","เหมียว"},{"SUPMIT!","เหมียว!"},{"TEST!","เหมียว!"},{"TestMode","เหมียว"},{"Help","เหมียว"},{"More Task","เหมียว"},{"S1","เหมียว"},{"S0","เหมียว!"},{"S2","เหมียว"},{"S3","เหมียว..."},{"S4","เหมียว..."},{"S5","เหมียว..."},{"S-1","เหมียว"},{"SERR","เหมียว!"},{"Start Clock","เหมียวเริ่ม"},{"Stop Clock","เหมียวหยุด"},{"Reset Clock","เหมียวรี"},{"File","เหมียว"},{"Result","เหมียว"},{"Point","เหมียว"},{"Show Comment","เหมียว"},{"Input","เหมียว"},{"Output","เหมียว"},{"JP","เหมียว"},{"JT","เหมียว"},{"JX","เหมียว"},{"J-","เหมียว"},{"JS","เหมียว"},{"JH","เหมียว"},{"JC","เหมียว"},{"J!","เหมียว!"},{"Jc","เหมียว"},{"J?","เหมียว!"},},
        };

        public Dictionary<string, float> Time_Factor = new Dictionary<string, float>
        {
            {"C",1},
            {"C++",1},
            {"Python",5},
            {"Java",1.5f}
        };


        public Dictionary<String, String> Lang_Path = new Dictionary<string, string>
        {
            {"C","<<Cur_Dir>>\\Compiler\\MinGW\\bin\\"},
            {"C++","<<Cur_Dir>>\\Compiler\\MinGW\\bin\\"},
            {"Python","<<Cur_Dir>>\\Compiler\\Python\\"},
            {"Java","<<Cur_Dir>>\\Compiler\\Java\\bin\\"}
        };



        public int SState = 1;
        public List<string[]> CommentO = new List<string[]> { new string[] { "Not submit yet?" } };
        public List<char> Verdicts = new List<char> { '?' };


        public string CUR_DIR = Directory.GetCurrentDirectory();

        public Over_Task Cur_Task_Info = new Over_Task();

        string DirOfSC = "";

        public Color_Theme Used_Color_Theme = new Color_Theme("Default");

        public DiscordRpcClient client;
        public bool DiscordConnect = false;


        public Color From_Otog_Color(Otog_Color x)
        {
            Color CL = Color.FromArgb(x.R, x.G, x.B);

            return CL;
        }

        public void Reload_Color()
        {
            
            /*foreach(ToolStripMenuItem menus in menuStrip1.Items)
            {
                menus.BackColor = From_Otog_Color(Used_Color_Theme.Back);
            }*/
            this.BackColor = From_Otog_Color(Used_Color_Theme.Back);
            this.ForeColor = From_Otog_Color(Used_Color_Theme.Text);

        }

        public bool Real_Con()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }



        public Otog()
        {
            InitializeComponent();


            if (!Directory.Exists(CUR_DIR + "\\Problems"))
            {
                MessageBox.Show("ไม่มีโจทย์อ่ะ");

                if (File.Exists(CUR_DIR + "\\ProblemDownload.exe"))
                {
                    Process.Start(CUR_DIR + "\\ProblemDownload.exe");
                }
                else
                {
                    MessageBox.Show("ไม่พบโปรแกรมดาวโหลดโจทย์", "เกิดข้อผิดพลาด");
                }

                Close();
            }


            if (!Directory.Exists(CUR_DIR + "\\Compiler"))
            {
                MessageBox.Show("ไม่มีตัวรันโปรแกรมอ่ะ");

                Process.Start("https://drive.google.com/drive/folders/1CbYPFDJ_nS1SgycmegMHNi2s8tRFNv7g?usp=sharing");

                Close();
            }

            if (!Directory.Exists(CUR_DIR + "\\StdJudge"))
            {
                MessageBox.Show("ไม่มีตัวตรวจอ่ะ");

                Process.Start("https://drive.google.com/drive/folders/1CbYPFDJ_nS1SgycmegMHNi2s8tRFNv7g?usp=sharing");

                Close();
            }

            foreach(string llang in Ava_Lang)
            {
                if(llang == "C++")
                {
                    if (File.Exists(CUR_DIR + "\\Path\\Cpp.cfg"))
                    {
                        Lang_Path[llang] = File.ReadAllText(CUR_DIR + "\\Path\\Cpp.cfg").Replace("<<Cur_Dir>>",CUR_DIR);
                    }
                }
                else
                {
                    if (File.Exists(CUR_DIR + "\\Path\\" + llang + ".cfg"))
                    {
                        Lang_Path[llang] = File.ReadAllText(CUR_DIR + "\\Path\\" + llang + ".cfg").Replace("<<Cur_Dir>>", CUR_DIR);
                    }
                }
                
            }


            

        }


        //Stopwatch
        public long Now_Time = 0;
        private long LS_Time = 0;


        private void Form1_Activated(object sender, System.EventArgs e)
        {
            ChangeState(SState);

            if (Directory.Exists(CUR_DIR + "\\Problems"))
            {
                string[] subdirectoryEntries = Directory.GetDirectories(CUR_DIR + "\\Problems");

                // Loop through them to see if they have any other subdirectories

                List<string> TodS = new List<string>();

                foreach (string subdirectory in subdirectoryEntries)
                    TodS.Add(subdirectory.Replace(CUR_DIR + "\\Problems\\", ""));

                CMP gg = new CMP();
                TodS.Sort(gg);

                foreach(string ee in TodS)
                    GroupTaskSelect.Items.Add(ee);

            }




        }


        private void STWStart_Click(object sender, EventArgs e)
        {
            STW_Reset.Visible = true;
            STW_Dis.Visible = true;

            if (STWStart.Text == G_Lang[Lang_Index]["Start Clock"])
            {
                menuStrip1.Enabled = false;
                GroupTaskSelect.Enabled = false;
                TaskSelect.Enabled = false;
                LS_Time = DateTime.Now.ToFileTimeUtc();
                STWStart.Text = G_Lang[Lang_Index]["Stop Clock"];
            }
            else
            {
                menuStrip1.Enabled = true;
                STWStart.Text = G_Lang[Lang_Index]["Start Clock"];
            }



        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (STWStart.Text == G_Lang[Lang_Index]["Stop Clock"])
            {
                Now_Time += (DateTime.Now.ToFileTimeUtc() - LS_Time) / 100000;
                LS_Time = DateTime.Now.ToFileTimeUtc();
            }
            STW_Dis.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                Now_Time / 6000 / 60,
                Now_Time / 6000 % 60,
                Now_Time / 100 % 60,
                Now_Time % 100
                );
        }

        private void STW_Reset_Click(object sender, EventArgs e)
        {


            STW_Dis.Visible = false;
            STW_Reset.Visible = false;
            GroupTaskSelect.Enabled = true;


            bool Isthere = false;
            foreach (string PP in GroupTaskSelect.Items)
            {
                Isthere = Isthere || (PP == GroupTaskSelect.Text);
            }
            TaskSelect.Enabled = Isthere;
            STWStart.Text = "Start Clock";
            Now_Time = 0;
            menuStrip1.Enabled = true;
        }

        public void ChangeState(int SSTATE)
        {
            SState = SSTATE;

            if (G_Lang[Lang_Index].ContainsKey("S" + SState.ToString()))
            {
                Sstate.Text = G_Lang[Lang_Index]["S" + SState.ToString()];
            }
            else
            {
                Sstate.Text = G_Lang[Lang_Index]["SERR"];
            }

            if (SState != 0)
            {
                Sstate.ForeColor = Color.IndianRed;

            }
            else
            {
                Sstate.ForeColor = Color.LightSeaGreen;
            }
            Sub.Enabled = SState == 0;
        }

        public void DEBUG(string Meow)
        {
            MessageBox.Show(Meow);
            Console.WriteLine(Meow);
        }




        private void GroupTaskSelect_Click(object sender, EventArgs e)
        {
            GroupTaskSelect.Items.Clear();

            //DEBUG(CUR_DIR);
            string[] subdirectoryEntries = Directory.GetDirectories(CUR_DIR + "\\Problems");

            // Loop through them to see if they have any other subdirectories

            foreach (string subdirectory in subdirectoryEntries)

                GroupTaskSelect.Items.Add(subdirectory.Replace(CUR_DIR + "\\Problems\\", ""));
        }

        private void GroupTaskSelect_TextChanged(object sender, EventArgs e)
        {
            bool Isthere = false;
            foreach (string PP in GroupTaskSelect.Items)
            {
                Isthere = Isthere || (PP == GroupTaskSelect.Text);
            }
            if (!Isthere)
            {
                SState = -1;
            }
            else
            {
                TaskSelect.Items.Clear();

                //DEBUG(CUR_DIR);
                string[] subdirectoryEntries = Directory.GetDirectories(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text);

                // Loop through them to see if they have any other subdirectories

                foreach (string subdirectory in subdirectoryEntries)

                    TaskSelect.Items.Add(subdirectory.Replace(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\", ""));

                SState = 1;
            }
            TaskSelect.Enabled = Isthere;
            TaskSelect.Text = "";



            ChangeState(SState);
        }

        private void TaskSelect_Click(object sender, EventArgs e)
        {
            TaskSelect.Items.Clear();

            //DEBUG(CUR_DIR);
            string[] subdirectoryEntries = Directory.GetDirectories(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text);

            // Loop through them to see if they have any other subdirectories

            List<string> TodS = new List<string>();

            foreach (string subdirectory in subdirectoryEntries)
                TodS.Add(subdirectory.Replace(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\", ""));

            CMP gg = new CMP();
            TodS.Sort(gg);

            foreach (string ee in TodS)
                TaskSelect.Items.Add(ee);



            


        }
        private void TaskSelect_TextChanged(object sender, EventArgs e)
        {
            bool Isthere = false;
            foreach (string PP in TaskSelect.Items)
            {
                Isthere = Isthere || (PP == TaskSelect.Text);
            }
            if (!Isthere)
            {
                SState = 1;
            }
            else if (File.Exists(DirOfSC))
            {
                SState = 0;


            }
            else
            {
                SState = 2;
            }
            Docu.Enabled = Isthere;

            if (Isthere)
            {
                //DEBUG("MEOW");

                string Pro_Path = CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text;

                if (File.Exists(Pro_Path + "\\Task_Com_Run.Isl"))
                {

                    Cur_Task_Info.Info_ComRun = JsonConvert.DeserializeObject<Dictionary<string, Com_Run>>(File.ReadAllText(Pro_Path + "\\Task_Com_Run.Isl"));
                }
                else Cur_Task_Info = new Over_Task("default");


                if (File.Exists(Pro_Path + "\\Task_Info.Isl"))
                {

                    Cur_Task_Info.Info_task = JsonConvert.DeserializeObject<Info_Task>(File.ReadAllText(Pro_Path + "\\Task_Info.Isl"));
                }
                else Cur_Task_Info.Info_task = new Info_Task();

                if (File.Exists(Pro_Path + "\\Task_Judge.Isl"))
                {

                    Cur_Task_Info.Judge_Task = JsonConvert.DeserializeObject<Mini_CMD>(File.ReadAllText(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\Task_Judge.Isl"));
                }
                else Cur_Task_Info.Judge_Task = new Mini_CMD("\"<<Cur_Dir>>\\Compiler\\Python\\python.exe\"", "\"<<Cur_Dir>>\\StdJudge\\judge.py\""); ;



                List<string> Task_Lang = Cur_Task_Info.Info_ComRun.Keys.ToList<string>();

                if (LangSelect.Items.Count == Task_Lang.Count)
                {
                    bool Is_Right = true;
                    foreach (string ll in Task_Lang)
                    {
                        if (!(LangSelect.Items.Contains(ll)))
                        {
                            Is_Right = false;
                        }
                    }

                    if (!Is_Right)
                    {
                        LangSelect.Items.Clear();
                        foreach (string ll in Task_Lang)
                        {
                            LangSelect.Items.Add(ll);
                        }
                        if (!Task_Lang.Contains(LangSelect.Text)) LangSelect.Text = Task_Lang[0];
                    }
                }
                else
                {
                    LangSelect.Items.Clear();
                    foreach (string ll in Task_Lang)
                    {
                        LangSelect.Items.Add(ll);
                    }

                    if (!Task_Lang.Contains(LangSelect.Text)) LangSelect.Text = Task_Lang[0];
                }


                TimeLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Time"] + ": {0:0.0}sec", (float)(Cur_Task_Info.Info_task.TimeLimit / 1000f) * Time_Factor[LangSelect.Text]);
                MemLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Mem"] + ": {0}mb", Cur_Task_Info.Info_task.MemLimit);
                ReloadRichPresence();
            }
            TimeLimitlabel.Visible = Isthere;
            MemLimitlabel.Visible = Isthere;




            ChangeState(SState);


        }



        private void DirBro_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            string Lang_Str = LangSelect.Text;
            if (!File_Type.ContainsKey(Lang_Str))
            {
                MessageBox.Show("ERROR", "Lang Error :(");
            }
            choofdlog.Filter = File_Type[Lang_Str];
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                DirOfSC = choofdlog.FileName;

                string Yor = choofdlog.FileName;

                int iind = 0; for (int i = 0; i < Yor.Length; i++) if (Yor[i] == '\\') iind = i;



                SrcNamae.Text = Yor.Substring(iind + 1, Yor.Length - (iind + 1));
            }
            else
            {
                DirOfSC = string.Empty;
            }


            //DEBUG(DirOfSC.Text);
            if (File.Exists(DirOfSC))
            {
                bool Isthere = false;
                foreach (string PP in TaskSelect.Items)
                {
                    Isthere = Isthere || (PP == TaskSelect.Text);
                }
                if (!Isthere)
                {
                    SState = 1;
                }
                else SState = 0;
            }
            else SState = 2;
            ChangeState(SState);

        }


        public int Hint_Crt = 1;


        private void SpoilBut_CheckedChanged(object sender, EventArgs e)
        {
            string[] ANN = new string[] {
                "จะดูสปอยแล้วออ",
                "แน่ใจแล้วหรอ",
                "คิดดีย์ๆ",
                "จะดูจริงๆหรอ",
                "Really?",
                "ถามรอบสุดท้าย\n\nเอาจริงนะ?",
                "ล้อเล่น :P ลองคิดใหม่...\n\nจะไม่ดูน่ะ",
                "ของจริงไม่มีดูเฉลยน่ะแบบนี้น่ะ",
                "ถามรอบสุดท้าย\n\nเอาจริงนะ?",
                "本気ですか？？？",
                "هل أنت واثق",
                "เคร งั้นไม่กวนละ :2"};
            if (SpoilBut.Checked)
            {
                if (Res.Text != "[]" && Res.Text != "[Compile Error!!!!]")
                {
                    int i = 0;
                    while (i < Hint_Crt && i < ANN.Length)
                    {
                        DialogResult result = MessageBox.Show(ANN[i], ANN[i], MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            SpoilBut.Checked = false;
                            break;
                        }
                        i++;
                    }
                }


                if (SpoilBut.Checked)
                {


                    TestSelect.Value = 1.2m;



                    label5.Visible = true;
                    TestEachRes.Visible = true;
                    TestSelect.Visible = true;


                    if (Res.Text != "[]" && Res.Text != "[Compile Error!!!!]") Hint_Crt++;
                }
                else
                {
                    label5.Visible = false;
                    TestEachRes.Visible = false;
                    TestSelect.Visible = false;

                    MessageBox.Show("เยี่ยมมาก ไอ้ต้าว", "เยี่ยมมาก ไอ้ต้าว");
                }



            }
            else
            {
                Commenttt.Lines = new string[] { };
                label5.Visible = false;
                TestEachRes.Visible = false;
                TestSelect.Visible = false;
            }
        }



        private void DirOfSC_TextChanged(object sender, EventArgs e)
        {
            //DEBUG(DirOfSC.Text);
            if (File.Exists(DirOfSC))
            {
                bool Isthere = false;
                foreach (string PP in TaskSelect.Items)
                {
                    Isthere = Isthere || (PP == TaskSelect.Text);
                }
                if (!Isthere)
                {
                    SState = 1;
                }
                else SState = 0;
            }
            else SState = 2;
            ChangeState(SState);
        }

        private void Help3_Click(object sender, EventArgs e)
        {

            if (File.Exists(CUR_DIR + "\\How To Use OTOGexe.pdf"))
            {
                Process.Start(CUR_DIR + "\\How To Use OTOGexe.pdf");
                return;
            }
            else
            {
                MessageBox.Show("หาไฟล์วิธีใช้ไม่เจออ่ะ", "Oh shoot");
            }
        }

        private void Help4_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            string[] Tuto = new string[] {
            "ญิณดีย์ต้อลลับซู่กาณฉ้วยเหรือ\nกด OK เพื่อไปยังหน้าต่อไป\nกด Cancel เพื่อการออกจากความช่วยเหลือ",
            "ในส่วนนี้จะให้ความช่วยเหลือเรื่อง\nสัญลักษณ์การตรวจ\n\nซึ่งจะมีแค่ 4 สถานะ",
            "P คือ ผ่าน",
            "- คือ คำตอบผิด",
            "T คือ เวลาเกิน",
            "X คือ โปรแกรมระเบิด\n    เช่น เอาตัวเลขหารด้วย 0\nเรียกสมาชิกที่ไม่มีจริง\n\nหรือถ้าเป็น python ก็คือโปรแกรมเกิดข้อผิดพลาด",
            "หากอยากรู้ว่าผิดเพราะอะไรก็สามารถ กด Show comment ได้\n\nแต่ทางที่ดีก็ควรคิดเองดีกว่า",
            "หากมีคำถามก็ถามมาที่ หา่้เ้ฟนด้รเ้"
            };

            string[] Titl = new string[] {
            "ญิณดีย์ต้อลลับ",
            "มันคืออะไร!!",
            "ผลตรวจ",
            "ผลตรวจ",
            "ผลตรวจ",
            "ผลตรวจ",
            "ทำไมถึงผิด",
            "การติดต่อ"
            };

            for (int i = 0; i < Tuto.Length; i++)
            {
                // Displays the MessageBox.

                result = MessageBox.Show(Tuto[i], string.Format("{2} ({0}/{1})", (i + 1).ToString(), Tuto.Length, Titl[i]), buttons);
                if (result == DialogResult.Cancel)
                {
                    break;
                }
            }


        }

        private void Sub_Click(object sender, EventArgs e)
        {
            if (SState != 0)
            {
                string ERR = "";

                switch (SState)
                {
                    case 1: ERR = "Select Task!!!"; break;
                    case 2: ERR = "Select File!!!"; break;
                }

                SystemSounds.Exclamation.Play();
                MessageBox.Show(ERR, "Hey man!!");
            }
            else
            {
                if (GroupTaskSelect.Text.Contains("Otog"))
                {
                    Warning.Text = "โจทย์ดังกล่าวได้เอามาจาก Otog.cf ซึ่งตัวทดสอบจะไม่เหมือนกับของจริง!";
                }
                else if (GroupTaskSelect.Text.Contains("EN811300"))
                {
                    Warning.Text = "พึ่งระลึกไว้เสมอว่า ตัวทดสอบนี้ ไม่เหมือน Autolab";
                }



                TaskSubed.Text = "[" + GroupTaskSelect.Text + "]" + TaskSelect.Text;
                FileSubed.Text = DirOfSC;
                SpoilBut.Checked = false;

                if (!Directory.Exists(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace"))
                    Directory.CreateDirectory(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace");

                if (TestModeCheck.Checked) DoTesting();
                else DoSubmission();
            }

        }





        private void Docu_Click(object sender, EventArgs e)
        {
            string filename = "Meow.pdf";

            if (File.Exists(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\doc.pdf"))
            {
                filename = CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\doc.pdf";
                Process.Start(filename);
            }
            else
            {
                DirectoryInfo d = new DirectoryInfo(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text);
                FileInfo[] Files = d.GetFiles("*.pdf"); //Getting Text files
                if (Files.Length > 0)
                {
                    Process.Start(Files[0].FullName);
                }
                else
                {
                    MessageBox.Show("หา Doc ไม่เจอง่ะ", "ไม่เจอ!!!");
                }
            }


        }


        private void TestModeCheck_CheckedChanged(object sender, EventArgs e)
        {
            labelInput.Visible = TestModeCheck.Checked;
            labelOutput.Visible = TestModeCheck.Checked;
            TestInput.Visible = TestModeCheck.Checked;
            TestOutput.Visible = TestModeCheck.Checked;
            Commenttt.Visible = !TestModeCheck.Checked;
            SpoilBut.Visible = !TestModeCheck.Checked;

            Sub.Text = TestModeCheck.Checked ? "Run!" : "Submit!";

            TestEachRes.Visible = false;
            TestSelect.Visible = false;
            label5.Visible = false;

            TestInput.Lines = new string[] { };
            TestOutput.Lines = new string[] { };
            Commenttt.Lines = new string[] { };

        }


        /// <summary>
        /// Part Compiled!!!!!!
        /// </summary>


        public void DoTesting()
        {

            TestOutput.Lines = new string[] { };

            Queue<string> DelTo = new Queue<string>();

            //Part Compile
            ChangeState(3);
            Process Runnu = new Process();
            string NewFile = "";

            {
                string[] SPL = FileSubed.Text.Split('\\');
                NewFile = CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\";

                string[] SPL2 = SPL[SPL.Length - 1].Split('.');

                if (LangSelect.Text != "Java") NewFile += "Src" + "." + SPL2[1];
                else
                {
                    DelTo.Enqueue(NewFile + SPL2[0] + ".class");
                    NewFile += SPL2[0] + "." + SPL2[1];
                }


            }


            File.Copy(FileSubed.Text, NewFile, true);
            DelTo.Enqueue(NewFile);

            string Lang_Str = LangSelect.Text;



            if (Cur_Task_Info.Info_ComRun.ContainsKey(Lang_Str))
            {
                Process p = new Process();

                Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.MainCMD = JsonConverting(Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.ArgsCMD = JsonConverting(Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Cur_Task_Info.Info_ComRun[Lang_Str].Runner.MainCMD = JsonConverting(Cur_Task_Info.Info_ComRun[Lang_Str].Runner.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Cur_Task_Info.Info_ComRun[Lang_Str].Runner.ArgsCMD = JsonConverting(Cur_Task_Info.Info_ComRun[Lang_Str].Runner.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                p.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.MainCMD, Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.ArgsCMD);


                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardError = true;
                //p.StartInfo.RedirectStandardOutput = true;


                p.Start();
                StreamReader reader = p.StandardError;
                string ERRRRROR = reader.ReadToEnd();

                p.WaitForExit();



                if (p.ExitCode != 0)
                {
                    ChangeState(0);
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show(G_Lang[Lang_Index]["CE"], "ERROR!");
                    Res.Text = "[Compile Error!!!!]";
                    Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);

                    CommentO.Clear();

                    CommentO.Add(ERRRRROR.Replace(CUR_DIR, "..").Split('\n'));
                    SpoilBut.Checked = true;
                    File.Delete(NewFile);
                    Poi.Text = "0";
                    return;
                }

                Runnu.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_ComRun[Lang_Str].Runner.MainCMD, Cur_Task_Info.Info_ComRun[Lang_Str].Runner.ArgsCMD);

                DelTo.Enqueue(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");

            }
            else
            {
                MessageBox.Show("ไม่รุจะคอมไพลยังไงอ่ะ", "เหมียว!!!");
                Res.Text = "[!!!!]";
                Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);
                ChangeState(0);
                Poi.Text = "0";
                return;
            }

            //Part Test
            ChangeState(5);




            string Otog_Verdict = "";
            string Test_Comment = "";
            Res.Text = string.Format("[Testing]");
            Res.ForeColor = Color.Black;

            string Test_Dir = CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\";

            Runnu.StartInfo.CreateNoWindow = true;
            Runnu.StartInfo.UseShellExecute = false;
            Runnu.StartInfo.RedirectStandardError = true;
            Runnu.StartInfo.RedirectStandardInput = true;
            Runnu.StartInfo.RedirectStandardOutput = true;

            Stopwatch watch = Stopwatch.StartNew();
            // the code that you want to measure comes here


            Runnu.Start();
            //DEBUG("Stdin!");
            StreamWriter INPUTT = Runnu.StandardInput;

            INPUTT.Write(string.Join("\n", TestInput.Lines));
            INPUTT.Close();
            long TimeUsed = 0;

            //DEBUG("Stdin Com!");

            int TimeLim = Cur_Task_Info.Info_task.TimeLimit;
            TimeLim = (int)(TimeLim * Time_Factor[Lang_Str]);

            Verdicts.Clear();
            if (!Runnu.WaitForExit(TimeLim))
            {
                watch.Stop();
                TimeUsed += watch.ElapsedMilliseconds;
                Otog_Verdict = G_Lang[Lang_Index]["SJT"];
                Runnu.Kill();
                //DEBUG("Time Out!");
                Verdicts.Add('T');
            }
            else
            {
                watch.Stop();
                TimeUsed += watch.ElapsedMilliseconds;


                if (Runnu.ExitCode != 0)
                {
                    Otog_Verdict = G_Lang[Lang_Index]["SJR"];
                    Verdicts.Add('X');
                }
                else
                {
                    StreamReader reader = Runnu.StandardOutput;
                    string output = reader.ReadToEnd();

                    output = output.Replace(((char)10).ToString(), "");

                    Otog_Verdict = "Test Complete";

                    TestOutput.Lines = output.Split((char)13);
                    Verdicts.Add('c');

                }


            }




            foreach (string F in DelTo) File.Delete(F);

            Res.Text = "[" + Otog_Verdict + "]";
            CommentO.Clear();

            if (Otog_Verdict == "Test Complete")
            {
                Res.ForeColor = Color.FromArgb(87 / 2, 229 / 2, 87 / 2);

                CommentO.Add(new string[] { "Test Ok :) YEY!" });
                STWStart.Text = "Start Clock";
                Poi.Text = "100";
            }
            else
            {
                Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);
                CommentO.Add(Test_Comment.Split('\n'));
                Poi.Text = "0";
            }

            TimeUse.Text = TimeUsed.ToString();

            ChangeState(0);
        }

        public void DoSubmission()
        {

            Queue<string> DelTo = new Queue<string>();

            //Part Compile
            ChangeState(3);
            Process Runnu = new Process();
            string NewFile = "";

            string[] SPL = FileSubed.Text.Split('\\');
            NewFile = CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\";

            string[] SPL2 = SPL[SPL.Length - 1].Split('.');

            if (LangSelect.Text != "Java") NewFile += "Src" + "." + SPL2[1];
            else
            {
                DelTo.Enqueue(NewFile + SPL2[0] + ".class");
                NewFile += SPL2[0] + "." + SPL2[1];
            }




            File.Copy(FileSubed.Text, NewFile, true);
            DelTo.Enqueue(NewFile);
            string Lang_Str = LangSelect.Text;

            if (Cur_Task_Info.Info_ComRun.ContainsKey(Lang_Str))
            {
                Process p = new Process();

                Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.MainCMD = JsonConverting(Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.ArgsCMD = JsonConverting(Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Cur_Task_Info.Info_ComRun[Lang_Str].Runner.MainCMD = JsonConverting(Cur_Task_Info.Info_ComRun[Lang_Str].Runner.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Cur_Task_Info.Info_ComRun[Lang_Str].Runner.ArgsCMD = JsonConverting(Cur_Task_Info.Info_ComRun[Lang_Str].Runner.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                p.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.MainCMD, Cur_Task_Info.Info_ComRun[Lang_Str].Compiler.ArgsCMD);


                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardError = true;
                //p.StartInfo.RedirectStandardOutput = true;


                p.Start();
                StreamReader reader = p.StandardError;
                string ERRRRROR = reader.ReadToEnd();

                p.WaitForExit();



                if (p.ExitCode != 0)
                {
                    ChangeState(0);
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show(G_Lang[Lang_Index]["JC"], "ERROR!");
                    Res.Text = "[Compile Error!!!!]";
                    Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);
                    CommentO.Clear();
                    Verdicts.Clear();


                    Verdicts.Add('C');
                    CommentO.Add(ERRRRROR.Replace(CUR_DIR, "..").Split('\n'));
                    SpoilBut.Checked = true;
                    File.Delete(NewFile);
                    Poi.Text = "0";
                    return;
                }



                DelTo.Enqueue(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");

            }
            else { 

                Verdicts.Clear();
                CommentO.Clear();
                Verdicts.Add('C');
                CommentO.Add(new string[] { "ไม่รุจะคอมไพลยังไงอ่ะ" });
                MessageBox.Show("ไม่รุจะคอมไพลยังไงอ่ะ", "เหมียว!!!");
                Res.Text = "[!!!!]";
                Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);
                ChangeState(0);
                Poi.Text = "0";
                return;
            }

            //Part Judge
            ChangeState(4);


            int Test_case = 1;
            int n_Test_case = 1;
            float Scoring = 0;
            float Max_Scoring = 0;
            long TimeUsed = 0;
            bool Fucked = false;

            Verdicts.Clear();
            CommentO.Clear();

            int TimeLim = Cur_Task_Info.Info_task.TimeLimit;
            TimeLim = (int)(TimeLim * Time_Factor[Lang_Str]);


            Test_case = 1;
            string Over_Verdict = "";


            Cur_Task_Info.Judge_Task.MainCMD = JsonConverting(Cur_Task_Info.Judge_Task.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
            Cur_Task_Info.Judge_Task.ArgsCMD = JsonConverting(Cur_Task_Info.Judge_Task.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");

            while (true)
            {
                Res.Text = "[Test #" + Test_case.ToString() + "]";
                Runnu.StartInfo = new ProcessStartInfo(Cur_Task_Info.Judge_Task.MainCMD,
                    Cur_Task_Info.Judge_Task.ArgsCMD + string.Format(" {0} {1} {2} \"{3}\" {4} {5}",
                    Test_case,
                    TimeLim,
                    Cur_Task_Info.Info_task.MemLimit,
                    CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\\\",
                    Cur_Task_Info.Info_ComRun[Lang_Str].Runner.MainCMD,
                    Cur_Task_Info.Info_ComRun[Lang_Str].Runner.ArgsCMD));



                Runnu.StartInfo.CreateNoWindow = true;
                Runnu.StartInfo.UseShellExecute = false;
                Runnu.StartInfo.RedirectStandardOutput = true;

                Runnu.Start();


                Runnu.WaitForExit();


                StreamReader reader = Runnu.StandardOutput;
                string output = reader.ReadToEnd();


                string[] VeryOut = output.Split(';');



                if (VeryOut.Length != 5)
                {
                    CommentO.Add(new string[] { "KSES said " + G_Lang[Lang_Index]["J!"] });
                    Verdicts.Add('!');
                    Fucked = true;
                    if (Over_Verdict == "")
                    {
                        Over_Verdict = G_Lang[Lang_Index]["J!"] + Test_case;
                    }
                    Test_case++;
                    continue;
                }


                if (VeryOut[0] == "E")
                {
                    break;
                }

                CommentO.Add(VeryOut[4].Split('\n'));
                Verdicts.Add(VeryOut[0][0]);

                if (VeryOut[0] != "P")
                {
                    Fucked = true;
                    if (Over_Verdict == "")
                    {
                        Over_Verdict = G_Lang[Lang_Index]["J"+ VeryOut[0]] + Test_case;
                    }
                }


                Scoring += float.Parse(VeryOut[2], CultureInfo.InvariantCulture.NumberFormat);
                Max_Scoring += float.Parse(VeryOut[3], CultureInfo.InvariantCulture.NumberFormat);

                n_Test_case = Test_case;
                Test_case++;

                TimeUsed += (int)(float.Parse(VeryOut[1], CultureInfo.InvariantCulture.NumberFormat));



            }







            foreach (string F in DelTo)
            {
                try
                {
                    File.Delete(F);
                }
                catch
                {

                }
            }

            if (Test_case <= 20) Res.Text = "[" + new string(Verdicts.ToArray()) + "]";
            else Res.Text = "[" + Over_Verdict + "]";

            if (!Fucked)
            {
                Res.ForeColor = Color.FromArgb(87 / 2, 229 / 2, 87 / 2);
                STWStart.Text = "Start Clock";
            }
            else
            {
                Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);
            }


            Poi.Text = string.Format("{0:0.##}", (float)(Scoring) / n_Test_case * 100);
            TimeUse.Text = TimeUsed.ToString();


            ChangeState(0);
        }

        private void CheckBut_Click(object sender, EventArgs e)
        {
            try
            {

                HttpClient Hclient = new HttpClient();
                Hclient.BaseAddress = new Uri("https://otogexe.firebaseio.com/Now_Ver.json");

                // Add an Accept header for JSON format.
                Hclient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = Hclient.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    string dataObjects = response.Content.ReadAsStringAsync().Result.Split('\"')[1];  //Make sure to add a reference to System.Net.Http.Formatting.dll



                    if (CurVer.Text != dataObjects)
                    {
                        MessageBox.Show(G_Lang[Lang_Index]["CUNup"], "Update!");

                        Hclient = new HttpClient();

                        Hclient.BaseAddress = new Uri("https://otogexe.firebaseio.com/Use_Updater.json");


                        Hclient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                        response = Hclient.GetAsync("").Result;

                        string ISU = response.Content.ReadAsStringAsync().Result;



                        if (ISU == "true")
                        {
                            Process.Start(CUR_DIR + "\\OtogUpgrader.exe");
                            Application.ExitThread();
                        }
                        else
                        {
                            Process.Start("https://drive.google.com/drive/folders/1CbYPFDJ_nS1SgycmegMHNi2s8tRFNv7g?usp=sharing");
                        }



                    }
                    else
                    {
                        MessageBox.Show(G_Lang[Lang_Index]["CUUp"], "Yey!");
                    }



                }
                else
                {
                    MessageBox.Show(G_Lang[Lang_Index]["CUNet"], "ERROR!");
                }

                //Make any other calls using HttpClient here.

                //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
                Hclient.Dispose();
            }
            catch
            {
                MessageBox.Show(G_Lang[Lang_Index]["CUNet"], "ERROR!");
            }
        }


        public string JsonConverting(string X, string Cur_Src, string Cur_RunExe)
        {
            string MEOW = X;

            MEOW = MEOW.Replace("<<Cur_Dir>>\\Compiler\\MinGW\\bin\\", Lang_Path["C"]);
            MEOW = MEOW.Replace("<<Cur_Dir>>\\Compiler\\MinGW\\bin\\", Lang_Path["C++"]);
            MEOW = MEOW.Replace("<<Cur_Dir>>\\Compiler\\Python\\", Lang_Path["Python"]);
            MEOW = MEOW.Replace("<<Cur_Dir>>\\Compiler\\Java\\bin\\", Lang_Path["Java"]);


            MEOW = MEOW.Replace("<<Cur_Dir>>", CUR_DIR);
            MEOW = MEOW.Replace("<<Cur_Src>>", Cur_Src);

            string Cur_Src_NoExt = Cur_Src;
            {
                int ld = -1;
                for (int i = 0; i < Cur_Src_NoExt.Length; i++) if (Cur_Src_NoExt[i] == '.') ld = i;

                if(ld != -1)
                {
                    Cur_Src_NoExt = Cur_Src_NoExt.Substring(0, ld);
                }

            }
            MEOW = MEOW.Replace("<<Cur_Src_NoExt>>", Cur_Src_NoExt);
            MEOW = MEOW.Replace("<<Cur_Run_Exe>>", Cur_RunExe);
            MEOW = MEOW.Replace("<<Cur_Problem>>", CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text);

            return MEOW;
        }

        private void LangSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TimeLimitlabel.Visible)
            {
                string Lang_Str = LangSelect.Text;






                TimeLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Time"] + ": {0:0.0}sec", (float)(Cur_Task_Info.Info_task.TimeLimit / 1000f) * Time_Factor[Lang_Str]);
                MemLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Mem"] + ": {0}mb", Cur_Task_Info.Info_task.MemLimit);
            }
            var rm = Properties.Resources.ResourceManager;
            LangPic.Image = (Image)rm.GetObject(LangSelect.Text);

            DirOfSC = "";
            ReloadRichPresence();
        }

        public int Lang_Index = 0;

        public void Use_Lang(int index)
        {
            Lang_Index = index;


            checkUpdateToolStripMenuItem.Text = G_Lang[index]["Check Update"];
            label1.Text = G_Lang[index]["Task"];
            Docu.Text = G_Lang[index]["Doc"];
            label4.Text = G_Lang[index]["Lang"];
            DirBro.Text = G_Lang[index]["Browse"];
            TestModeCheck.Text = G_Lang[index]["TestMode"];
            STW_Reset.Text = G_Lang[index]["Reset Clock"];



            label3.Text = G_Lang[index]["Task"] + " :";
            label2.Text = G_Lang[index]["File"] + " :";
            ResLabel.Text = G_Lang[index]["Result"] + " :";
            PointLa.Text = G_Lang[index]["Point"] + " :";
            TimeLa.Text = G_Lang[index]["Time"] + " :";
            SpoilBut.Text = G_Lang[index]["Show Comment"];
            labelInput.Text = G_Lang[index]["Input"];
            labelOutput.Text = G_Lang[index]["Output"];
            STWStart.Text = G_Lang[index]["Start Clock"];

            moreTaskToolStripMenuItem.Text = G_Lang[index]["More Task"];
            helpToolStripMenuItem.Text = G_Lang[index]["Help"];

            if (TimeLimitlabel.Visible)
            {
                string Meow = LangSelect.Text;
                float Fac = Time_Factor[Meow];
                TimeLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Time"] + ": {0:0.0}sec", (float)(Cur_Task_Info.Info_task.TimeLimit / 1000f) * Fac);
                MemLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Mem"] + ": {0}mb", Cur_Task_Info.Info_task.MemLimit);
            }

            ChangeState(SState);

        }


        private void checkUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                HttpClient Hclient = new HttpClient();
                Hclient.BaseAddress = new Uri("https://otogexe.firebaseio.com/Now_Ver.json");

                // Add an Accept header for JSON format.
                Hclient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = Hclient.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    string dataObjects = response.Content.ReadAsStringAsync().Result.Split('\"')[1];  //Make sure to add a reference to System.Net.Http.Formatting.dll



                    if (CurVer.Text != dataObjects)
                    {
                        MessageBox.Show(G_Lang[Lang_Index]["CUNup"], "Update!");

                        Hclient = new HttpClient();

                        Hclient.BaseAddress = new Uri("https://otogexe.firebaseio.com/Use_Updater.json");


                        Hclient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                        response = Hclient.GetAsync("").Result;

                        string ISU = response.Content.ReadAsStringAsync().Result;



                        if (ISU == "true")
                        {
                            Process.Start(CUR_DIR + "\\OtogUpgrader.exe");
                            Application.ExitThread();
                        }
                        else
                        {
                            Process.Start("https://drive.google.com/drive/folders/1CbYPFDJ_nS1SgycmegMHNi2s8tRFNv7g?usp=sharing");
                        }



                    }
                    else
                    {
                        MessageBox.Show(G_Lang[Lang_Index]["CUUp"], "Yey!");
                    }



                }
                else
                {
                    MessageBox.Show(G_Lang[Lang_Index]["CUNet"], "ERROR!");
                }

                //Make any other calls using HttpClient here.

                //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
                Hclient.Dispose();
            }
            catch
            {
                MessageBox.Show(G_Lang[Lang_Index]["CUNet"], "ERROR!");
            }
        }

        private void moreTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(CUR_DIR + "\\ProblemDownload.exe"))
            {
                Process.Start(CUR_DIR + "\\ProblemDownload.exe");
            }
            else
            {
                MessageBox.Show("ไม่พบโปรแกรมดาวโหลดโจทย์", "เกิดข้อผิดพลาด");
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(CUR_DIR + "\\How To Use OTOGexe.pdf"))
            {
                Process.Start(CUR_DIR + "\\How To Use OTOGexe.pdf");
                return;
            }
            else
            {
                MessageBox.Show("หาไฟล์วิธีใช้ไม่เจออ่ะ", "Oh shoot");
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Use_Lang(0);
        }

        private void ภาษาไทยToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Use_Lang(1);
        }

        private void พาศาทยToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Use_Lang(2);
        }

        private void ภาษาแมวToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Use_Lang(3);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            TestSelect.Value = (int)TestSelect.Value;

            int VV = (int)TestSelect.Value;

            if (VV > Verdicts.Count)
            {
                SystemSounds.Exclamation.Play();
                VV = Verdicts.Count;
                TestSelect.Value = VV;
            }
            else if (VV <= 0)
            {
                SystemSounds.Exclamation.Play();
                VV = 1;
                TestSelect.Value = 1;
            }

            if (G_Lang[Lang_Index].ContainsKey("J" + Verdicts[VV - 1]))
            {
                TestEachRes.Text = "Test#" + VV.ToString() + ":" + G_Lang[Lang_Index]["J" + Verdicts[VV - 1]];

            }
            else
            {
                TestEachRes.Text = "Test#" + VV.ToString() + ":" + G_Lang[Lang_Index]["J?"];
            }
            Commenttt.Lines = CommentO[(int)TestSelect.Value - 1];

            switch (Verdicts[VV - 1])
            {
                case 'P':
                    TestEachRes.ForeColor = Color.MediumSeaGreen;
                    break;
                case '-':
                case 'X':
                case 'T':
                    TestEachRes.ForeColor = Color.MediumVioletRed;
                    break;
                case 'H':
                    TestEachRes.ForeColor = Color.OrangeRed;
                    break;
                case 'S':
                    TestEachRes.ForeColor = Color.DarkRed;
                    break;
                case '!':
                    TestEachRes.ForeColor = Color.Chocolate;
                    break;
                case 'c':
                    TestEachRes.ForeColor = Color.Orange;
                    break;
                default:
                    TestEachRes.ForeColor = Color.MidnightBlue;
                    break;
            }



        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Used_Color_Theme = new Color_Theme("default");
            Reload_Color();
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Used_Color_Theme = new Color_Theme("default");


            Used_Color_Theme.Back = new Otog_Color("#000000");
            Used_Color_Theme.Text = new Otog_Color("#FFFFFF");



            Reload_Color();
        }

        public void ReloadRichPresence()
        {
            if (DiscordConnect)
            {
                string Now_Details = "Idle";
                string Now_State = "*AFK*";
                string SmallImageKey = LangSelect.Text.ToLower();

                if (TaskSelect.Text != "")
                {
                    Now_Details = GroupTaskSelect.Text;
                    Now_State = TaskSelect.Text;
                }

                if (LangSelect.Text == "C++") SmallImageKey = "cpp";

                RichPresence RPC = new RichPresence()
                {
                    Details = Now_Details,
                    State = Now_State,


                    Assets = new Assets()
                    {
                        LargeImageKey = "otog_doughnut",
                        LargeImageText = "Otog.exe",
                        SmallImageKey = SmallImageKey,
                        SmallImageText = "Writing in " + LangSelect.Text + "..."
                    }
                };

                if (TaskSelect.Text != "")
                {
                    RPC.Timestamps = Timestamps.Now;
                }


                client.SetPresence(RPC);
            }
            
        }

        private void conectToDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Connecting to discord...");
            try
            {
                client = new DiscordRpcClient("787888159593070632");
                client.Initialize();
                DiscordConnect = true;
                ReloadRichPresence();
                MessageBox.Show("Connecting Complete");
            }
            catch
            {
                DiscordConnect = false;
                MessageBox.Show("Fail to connect");
            }

            
            

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            
        }

    }




    public class Mini_CMD
    {
        public string MainCMD
        {
            set; get;
        }
        public string ArgsCMD
        {
            set; get;
        }

        public Mini_CMD()
        {
            MainCMD = "echo Meow";
            ArgsCMD = "";
        }

        public Mini_CMD(string a, string b)
        {
            MainCMD = a;
            ArgsCMD = b;
        }

    }

    public class Info_Task
    {
        public int TimeLimit
        {
            get; set;
        } = 1000;
        public int MemLimit
        {
            get; set;
        } = 256;


    };


    public class Com_Run
    {
        public Mini_CMD Compiler
        {
            set; get;
        } = new Mini_CMD();
        public Mini_CMD Runner
        {
            set; get;
        } = new Mini_CMD();

        public Com_Run(string com_exe, string com_args, string run_exe, string run_args)
        {
            Compiler.MainCMD = com_exe;
            Compiler.ArgsCMD = com_args;
            Runner.MainCMD = run_exe;
            Runner.ArgsCMD = run_args;
        }

    }

    public class Over_Task
    {
        public Info_Task Info_task
        {
            set; get;
        } = new Info_Task();

        public Dictionary<string, Com_Run> Info_ComRun
        {
            set; get;
        } = new Dictionary<string, Com_Run>();

        public Mini_CMD Judge_Task
        {
            set; get;
        } = new Mini_CMD("\"<<Cur_Dir>>\\Compiler\\Python\\python.exe\"", "\"<<Cur_Dir>>\\StdJudge\\judge.py\"");

        public Over_Task()
        {

        }

        public Over_Task(string Typee)
        {
            if (Typee.ToLower() == "default")
            {
                Info_ComRun = new Dictionary<string, Com_Run>()
                {
                    {"C",new Com_Run("\"<<Cur_Dir>>\\Compiler\\MinGW\\bin\\gcc.exe\"", "-O2 \"<<Cur_Src>>\" -o \"<<Cur_Run_Exe>>\"","\"<<Cur_Run_Exe>>\"", "\"\"")},
                    {"C++",new Com_Run("\"<<Cur_Dir>>\\Compiler\\MinGW\\bin\\g++.exe\"", "-O2 -std=c++17 \"<<Cur_Src>>\" -o \"<<Cur_Run_Exe>>\"","\"<<Cur_Run_Exe>>\"", "\"\"")},
                    {"Python",new Com_Run("\"<<Cur_Dir>>\\Compiler\\Python\\python.exe\"", "-m py_compile \"<<Cur_Src>>\"","\"<<Cur_Dir>>\\Compiler\\Python\\python.exe\"", "\"<<Cur_Src>>\"")},
                    {"Java",new Com_Run("\"<<Cur_Dir>>\\Compiler\\Java\\bin\\javac.exe\"", "\"<<Cur_Src>>\"","\"<<Cur_Dir>>\\Compiler\\Java\\bin\\java.exe\"", "\"<<Cur_Src>>\"")},
                };
            }
        }

    };

    public class Otog_Color
    {
        public int R
        {
            get; set;
        } = 255;
        public int G
        {
            get; set;
        } = 255;
        public int B
        {
            get; set;
        } = 255;
        public int A
        {
            get; set;
        } = 255;

        public Otog_Color(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        public Otog_Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
            A = 255;
        }

        public Otog_Color(string Hex)
        {
            int C2I(char x)
            {
                switch (x)
                {
                    case '0': return 0;
                    case '1': return 1;
                    case '2': return 2;
                    case '3': return 3;
                    case '4': return 4;
                    case '5': return 5;
                    case '6': return 6;
                    case '7': return 7;
                    case '8': return 8;
                    case '9': return 9;
                    case 'A': case 'a': return 10;
                    case 'B': case 'b': return 11;
                    case 'C': case 'c': return 12;
                    case 'D': case 'd': return 13;
                    case 'E': case 'e': return 14;
                    case 'F': case 'f': return 15;
                }
                return 0;
            }


            if (Hex.Length == 9)
            {
                A = C2I(Hex[1]) * 16 + C2I(Hex[2]);
                R = C2I(Hex[3]) * 16 + C2I(Hex[4]);
                G = C2I(Hex[5]) * 16 + C2I(Hex[6]);
                B = C2I(Hex[7]) * 16 + C2I(Hex[8]);
            }
            else if (Hex.Length == 7)
            {
                R = C2I(Hex[1]) * 16 + C2I(Hex[2]);
                G = C2I(Hex[3]) * 16 + C2I(Hex[4]);
                B = C2I(Hex[5]) * 16 + C2I(Hex[6]);
            }


        }

        public Otog_Color(Color CSColor)
        {
            R = CSColor.R;
            G = CSColor.G;
            B = CSColor.B;
            A = CSColor.A;
        }

        public Otog_Color()
        {
            R = 255;
            G = 255;
            B = 255;
            A = 255;
        }

    }

    public class Color_Theme
    {
        public Otog_Color Back
        {
            get; set;
        } = new Otog_Color();


        public Otog_Color Text
        {
            get; set;
        } = new Otog_Color();



        public Otog_Color State_NotReady
        {
            get; set;
        } = new Otog_Color();

        public Otog_Color State_Ready
        {
            get; set;
        } = new Otog_Color();



        public Otog_Color Verdict_P
        {
            get; set;
        } = new Otog_Color();

        public Otog_Color Verdict_W
        {
            get; set;
        } = new Otog_Color();

        public Otog_Color Verdict_H
        {
            get; set;
        } = new Otog_Color();

        public Otog_Color Verdict_S
        {
            get; set;
        } = new Otog_Color();

        public Otog_Color Verdict_e
        {
            get; set;
        } = new Otog_Color();

        public Otog_Color Verdict_c
        {
            get; set;
        } = new Otog_Color();

        public Otog_Color Verdict_d
        {
            get; set;
        } = new Otog_Color();


        public Color_Theme()
        {

        }

        public Color_Theme(string Typee)
        {
            if (Typee.ToLower() == "default")
            {
                Back = new Otog_Color("#F0F0F0");
                Text = new Otog_Color("#000000");

                State_NotReady = new Otog_Color(Color.IndianRed);
                State_Ready = new Otog_Color(Color.LightSeaGreen);

                Verdict_P = new Otog_Color(Color.MediumSeaGreen);
                Verdict_W = new Otog_Color(Color.MediumVioletRed);
                Verdict_H = new Otog_Color(Color.OrangeRed);
                Verdict_S = new Otog_Color(Color.DarkRed);
                Verdict_e = new Otog_Color(Color.AliceBlue);
                Verdict_c = new Otog_Color(Color.Orange);
                Verdict_d = new Otog_Color(Color.MidnightBlue);
            }
        }

    };



    class CMP : IComparer<string>
    {
        public static bool IsNum(char x)
        {
            return (x >= '0' && x <= '9');
        }

        public int Compare(string x, string y)
        {
            List<string> Xs = new List<string>();
            List<int> Xi = new List<int>();
            List<char> Xt = new List<char>();

            bool Is_Char = true;
            string tods = "";
            int todi = 0;
            if (IsNum(x[0])) Is_Char = false;
            for (int i = 0; i < x.Length; i++)
            {
                if (Is_Char)
                {
                    if (!IsNum(x[i]))
                    {
                        tods += x[i];
                    }
                    else
                    {
                        Xs.Add(tods);
                        Xt.Add('S');
                        todi = x[i] - '0';
                        Is_Char = false;
                    }
                }
                else
                {
                    if (IsNum(x[i]))
                    {
                        todi *= 10;
                        todi += (int)x[i] - '0';
                    }
                    else
                    {
                        Xi.Add(todi);
                        Xt.Add('I');
                        tods = "";
                        tods += x[i];
                        Is_Char = true;
                    }
                }
            }
            if (Is_Char)
            {
                Xs.Add(tods);
                Xt.Add('S');
            }
            else
            {
                Xi.Add(todi);
                Xt.Add('i');
            }


            List<string> Ys = new List<string>();
            List<int> Yi = new List<int>();
            List<char> Yt = new List<char>();

            Is_Char = true;
            tods = "";
            todi = 0;
            if (IsNum(y[0])) Is_Char = false;
            for (int i = 0; i < y.Length; i++)
            {
                if (Is_Char)
                {
                    if (!IsNum(y[i]))
                    {
                        tods += y[i];
                    }
                    else
                    {
                        Ys.Add(tods);
                        Yt.Add('S');
                        todi = (int)y[i] - '0';
                        Is_Char = false;
                    }
                }
                else
                {
                    if (IsNum(y[i]))
                    {
                        todi *= 10;
                        todi += y[i] - '0';
                    }
                    else
                    {
                        Yi.Add(todi);
                        Yt.Add('I');
                        tods = "";
                        tods += y[i];
                        Is_Char = true;
                    }
                }
            }



            if (Is_Char)
            {
                Ys.Add(tods);
                Yt.Add('S');
            }
            else
            {
                Yi.Add(todi);
                Yt.Add('i');
            }


            if (Xt[0] != Yt[0]) return Xt[0].CompareTo(Yt[0]);
            int Ci = 0;

            char T = Xt[0];

            while (true)
            {
                if (T == 'S')
                {



                    if (Ci >= Xs.Count && Ci < Ys.Count) return -1;
                    if (Ci >= Ys.Count && Ci < Xs.Count) return 1;
                    if (Ci >= Xs.Count && Ci >= Ys.Count) return 0;

                    //Console.WriteLine("S..."+Xs[Ci]+"..vs.."+Ys[Ci]);

                    if (Xs[Ci] != Ys[Ci]) return Xs[Ci].CompareTo(Ys[Ci]);

                    if (Xt[0] == 'I') Ci++;
                    T = 'I';
                }
                else
                {

                    if (Ci >= Xi.Count && Ci < Yi.Count) return -1;
                    if (Ci >= Yi.Count && Ci < Xi.Count) return 1;
                    if (Ci >= Xi.Count && Ci >= Yi.Count) return 0;

                    //Console.WriteLine("S..."+Xs[Ci]+"..vs.."+Ys[Ci]);

                    if (Xi[Ci] != Yi[Ci]) return Xi[Ci].CompareTo(Yi[Ci]);

                    if (Xt[0] == 'S') Ci++;
                    T = 'S';
                }
            }

        }
    };


}
