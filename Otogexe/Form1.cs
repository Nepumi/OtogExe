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



namespace Otogexe
{

    


    public partial class Otog : Form
    {

        public const int MAX_TESTCASE = 300;

        public  List<string> Ava_Lang = new List<string> { "C","C++", "Python","Java"};
        public Dictionary<string, string> File_Type = new Dictionary<string, string>() {
            {"C","C source code|*.c;*.i"},
            {"C++","C++ source code|*.cpp;*.cc;*.cxx;*.c++;*.hpp;*.hh;*.hxx;*.h++;*.h;*.ii;"},
            {"Python","Python source code|*.py;*.rpy;*.pyw;*.cpy;*.gyp;*.gypi;*.pyi;*.ipy;"},
            {"Java","Java source code|*.java;*.jav;"}
        };

        public List<Dictionary<string, string>> G_Lang = new List<Dictionary<string, string>>()
        {
           new Dictionary<string, string>{
               {"Call_Lang","English" },
               {"Check Update","Check Update" },

               {"CUNet","Can't Connect \n\n :(" },
               {"CUUp","It's Up to date\n\n Yey!" },
               {"CUNup","There are new Update" },

               {"Task","Task" },
               {"Lang","Lang" },
               {"Time","Time" },
               {"Mem","Mem" },
               {"Doc","Doc" },
               {"Browse","Browse" },
               {"SUPMIT!","SUBMIT!" },
               {"TEST!","TEST!" },
               {"TestMode","Test Mode" },
               {"Help","Help!"},
               {"More Task","More Task"},

               {"S1","Select Task" },
               {"S0","Ready!" },
               {"S2","Select file" },
               {"S3","Compile..." },
               {"S4","Judging..." },
               {"S5","Testing..." },
               {"S-1","Select Group" },
               {"SERR","ERROR!" },

               {"Start Clock","Start Clock" },
               {"Stop Clock","Stop Clock" },
               {"Reset Clock","Reset Clock" },

               {"File","File" },
               {"Result","Result" },
               {"Point","Score" },
               {"Show Comment","Show Comment" },
               {"Input","Input" },
               {"Output","Output" },

               {"JWAL","Expected {0} lines\nbut yours {1} lines in test case {2}\n\nInput:\n{5}\n\nExpected:\n{3}\n\nYours:\n{4}" },
               {"JWA","In line{0}\nExpected\n{1}\nbut yours\n{2}\nin test case {3}\n\n*Overall*\n\nInput:\n{6}\n\nExpected:\n{4}\n\nYours:\n{5}" },
               {"JWAC","Wrong answer in Test case {0}\n\nThis is Special judge\nSo this is Judge message:\n{1}" },
               {"JT","Time limit exceed in Test case {0}" },
               {"JR","Runtime Error in Test case {0}" },
               {"CE","Compile Error!" },
               {"SJT","Time limit exceed" },
               {"SJR","Runtime Error" },
               {"SJE","Judge Error" },
               {"SJH","Partially Correct" },
               {"SJW","Wrong answer" },
               {"JE","Judge Error!"},
               {"PE","Problem Error!"},
               {"JS","Skiping Test case {0}"},
               {"JH","Partially Correct in Test case {0}\n\nThis is Special judge\nSo this is Judge message:\n{1}"}
           },
           new Dictionary<string, string>{
               {"Call_Lang","ภาษาไทย" },
               {"Check Update","ตรวจอัพเกรด" },

               {"CUNet","ไม่สามารถเชื่อมต่อ \n\n :(" },
               {"CUUp","เป็นเวอร์ชั่นปัจจุบันแล้ว\n\n สวยพี่สวย!" },
               {"CUNup","มีอัพเดธใหม่" },

               {"Task","ข้อ" },
               {"Lang","ภาษา" },
               {"Time","เวลา" },
               {"Mem","ความจำ" },
               {"Doc","โจทย์" },
               {"Browse","เลือกไฟล์" },
               {"SUPMIT!","ส่ง!" },
               {"TEST!","ทดสอบ!" },
               {"TestMode","โหมดทดสอบ" },
               {"Help","ช่วยเหลือ"},
               {"More Task","โจทย์ใหม่"},

               {"S1","กรุณาเลือกโจทย์" },
               {"S0","พร้อม!" },
               {"S2","กรุณาเลือกไฟล์" },
               {"S3","กำลังคอมไพล์..." },
               {"S4","กำลังตรวจ..." },
               {"S5","กำลังทดสอบ..." },
               {"S-1","กรุณาเลือกกลุ่มโจทย์" },
               {"SERR","ERROR!" },

               {"Start Clock","เริ่มจับเวลา" },
               {"Stop Clock","หยุดเวลา" },
               {"Reset Clock","รีเซ็ตเวลา" },

               {"File","ไฟล์" },
               {"Result","ผลการตรวจ" },
               {"Point","คะแนน" },
               {"Show Comment","แสดงคอมเม้น" },
               {"Input","ข้อมูลนำเข้า" },
               {"Output","ข้อมูลส่งออก" },


               {"JWAL","คาดหวังว่าได้ {0} บรรทัด\nแต่โปรแกรมแกมี {1} บรรทัด ในตัวทดสอบที่ {2}\nอินพุต:\n{5}\n\nเฉลย:\n{3}\n\nของแก:\n{4}" },
               {"JWA","ในบรรทัดที่{0}\nคาดหวังว่าได้\n{1}\nแต่ของแกคือ\n{2}\nในตัวทดสอบที่ {3}\n\n*ภาพรวม*\n\nอินพุต:\n{6}\n\nเฉลย:\n{4}\n\nของแก:\n{5}" },
               {"JWAC","คำตอบไม่ถูกต้องในตัวทดสอบที่ {0}\n\nข้อนี้จะมีการตรวจแบบพิเศษ\nซึ่งนี้คือข้อความที่มาจากการตรวจดังกล่าว:\n{1}" },

               {"JT","เวลาเกินในตัวทดสอบที่ {0}" },
               {"JR","โปรแกรมระเบิดตัวเองในตัวทดสอบที่ {0}" },
               {"CE","คอมไพล์ เออเร่อ!" },
               {"SJT","เวลาเกิน" },
               {"SJR","โปรแกรมระเบิด" },
               {"SJE","โปรแกรมตรวจผิดพลาด" },
               {"SJH","ได้คะแนนบางส่วน" },
               {"SJW","คำตอบผิด" },
               {"JE","การตรวจมีข้อผิดพลาด"},
               {"PE","โจทย์มีข้อผิดพลาด"},
               {"JS","ข้ามการตรวจในตัวทดสอบที่ {0}"},
               {"JH","ได้คะแนน*บาง*ส่วนในตัวทดสอบที่ {0}\n\nข้อนี้จะมีการตรวจแบบพิเศษ\nซึ่งนี้คือข้อความที่มาจากการตรวจดังกล่าว:\n{1}"}
           },
            new Dictionary<string, string>{
               {"Call_Lang","พาศาทัย" },
               {"Check Update","ตลวจอัปเกลด" },

               {"CUNet","มั่ยมีย์แณ็ตแร้วจะดูย์หยังงัย \n\n สึส" },
               {"CUUp","มั่ยต่องอับหลอก\n\n โต๊แร้ว!" },
               {"CUNup","ไปอัพพพพพพพพ" },

               {"Task","ค่อ" },
               {"Lang","พาศา" },
               {"Time","เพลา" },
               {"Mem","คามจัม" },
               {"Doc","จด" },
               {"Browse","เริอกไฟ" },
               {"SUPMIT!","ศ่ง!" },
               {"TEST!","ธดซอบ!" },
               {"TestMode","โมดธดซอบ" },

               {"S1","รุกณาเรือกจด" },
               {"S0","พร้อม!" },
               {"S2","รุกณาเรือกไฟ" },
               {"S3","กำลังไฟฟ้า..." },
               {"S4","กำลังดู..." },
               {"S5","กำลังทำอะไรไม่รู่..." },
               {"S-1","รุกณาเรือกกุ่ลมโจ" },
               {"SERR","ERROR!" },
               {"Help","เหมียว"},
               {"More Task","จดมั่ย"},

               {"Start Clock","เริ่มเพลา" },
               {"Stop Clock","หยุดเพลา" },
               {"Reset Clock","รีเพลา" },

               {"File","ไฟ" },
               {"Result","โพล" },
               {"Point","ฅ๊ะแน็ต" },
               {"Show Comment","แส-ดงคอมโปร" },
               {"Input","เข้าๆ" },
               {"Output","ออกๆ" },

               {"JWAL","ยักดัย {0} บันธัด\nแต่มึงให้ {1} บันธัด {2}\n\nใส่ข้าวปาย:\n{5}\n\nเชลย:\n{3}\n\nมึง:\n{4}" },
               {"JWA","บรรได{0}\nยักดัย\n{1}\nแต่ของมึงคือลือ\n{2}\n{3}\n\n*เหมียว*\n\nใส่ข้าวปาย:\n{6}\n\nเชลย:\n{4}\n\nมึง:\n{5}" },
               {"JWAC","อ่อนว่ะ {0}\n\nเจอของขลังของโจทย์ข้อนี้ล่ะสิ\n555555มนต์สะกดจิดมึงไว้ว่า:\n{1}" },
               {"JT","ช้า!!!!!!! {0}" },
               {"JR","ระเบิด!!!!!!! {0}" },
               {"CE","@#%*()@$^(@^%)(!@*" },
               {"SJT","ระเบิดเวลาาาาาาา" },
               {"SJR","อ้าาาาาาาาาาาาาาาาาาาาาาาาาาาาาาา" },
               {"SJE","โจทย์กาก" },
               {"SJH","ว้ายๆๆๆได้คะแนนแข่บังสวน" },
               {"SJW","อ่อนว่ะ" },
               {"JE","เหมียว"},
               {"PE","โจทย์กาก"},
               {"JS","ไม่ตรวจ({0})อ่ะ หยิ่ง"},
                {"JH","ว้ายๆๆๆตัวทดสอบที่ {0}\n\nได้คะแนนแข่บังสวน\n\nเจอของขลังของโจทย์ข้อนี้ล่ะสิ\n555555มนต์สะกดจิดมึงไว้ว่า:\n{1}"}
           },
            new Dictionary<string, string>{
               {"Call_Lang","ภาษาแมว" },
               {"Check Update","เหมียว" },

               {"CUNet","เหมียวเน็ต" },
               {"CUUp","เหมียวเย่" },
               {"CUNup","เหมียวโน" },

               {"Task","เหมียว" },
               {"Lang","เหมียว" },
               {"Time","เหมียว" },
               {"Mem","เหมียว" },
               {"Doc","เหมียว" },
               {"Browse","เหมียว" },
               {"SUPMIT!","เหมียว!" },
               {"TEST!","เหมียว!" },
               {"TestMode","เหมียว" },
               {"Help","เหมียว"},
               {"More Task","เหมียว"},

               {"S1","เหมียว" },
               {"S0","เหมียว!" },
               {"S2","เหมียว" },
               {"S3","เหมียว..." },
               {"S4","เหมียว..." },
               {"S5","เหมียว..." },
               {"S-1","เหมียว" },
               {"SERR","เหมียว!" },

               {"Start Clock","เหมียวเริ่ม" },
               {"Stop Clock","เหมียวหยุด" },
               {"Reset Clock","เหมียวรี" },

               {"File","เหมียว" },
               {"Result","เหมียว" },
               {"Point","เหมียว" },
               {"Show Comment","เหมียว" },
               {"Input","เหมียว" },
               {"Output","เหมียว" },

               {"JWAL","เหมียว {0} เหมียว\nเหมียว {1} เหมียว {2}\n\nเหมียว:\n{5}\n\nเหมียว:\n{3}\n\nเหมียวเหงา:\n{4}" },
               {"JWA","เหมียว{0}\nเหมียว\n{1}\nเหมียว\n{2}\n เหมียว{3}\n\n*เหมียว*\n\nเหมียว:\n{6}\n\nเหมียว:\n{4}\n\nเหมียวเหงา:\n{5}" },
               {"JWAC","เหมียว {0}\n\nเหมียวเเหมี่ยว\nเหมี่ยวเหมี่ยวเหมียวเหมียว:\n{1}" },
               {"JT","เหมียว {0}" },
               {"JR","เหมียว {0}" },
               {"CE","เหมียว" },
               {"SJT","เหมียว" },
               {"SJR","เหมียว" },
               {"SJE","เหมียว" },
               {"SJH","เหมียว" },
               {"SJW","เหมียว" },
               {"JE","เหมียว"},
               {"PE","เหมียว"},
               {"JS","เหมียว"},
                {"JH","เหมียวไม่เต็ม\n\nเหมียวเเหมี่ยว\nเหมี่ยวเหมี่ยวเหมียวเหมียว:\n{1}"}
           },
        };

        public Dictionary<string, float> Time_Factor = new Dictionary<string, float>
        {
            {"C",1},
            {"C++",1},
            {"Python",5},
            {"Java",1.5f}
        };



        public int SState = 1;
        public string[] CommentO = new string[] { "Not submit yet?" };

        public string CUR_DIR = Directory.GetCurrentDirectory();

        public Over_Task Cur_Task_Info = new Over_Task();


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

                foreach (string subdirectory in subdirectoryEntries)

                    GroupTaskSelect.Items.Add(subdirectory.Replace(CUR_DIR + "\\Problems\\", ""));
                //DEBUG(CUR_DIR);

            }




        }


        private void STWStart_Click(object sender, EventArgs e)
        {
            STW_Reset.Visible = true;
            STW_Dis.Visible = true;

            Help3.Enabled = false;

            if (STWStart.Text == G_Lang[Lang_Index]["Start Clock"])
            {
                LangChan.Enabled = false;
                GroupTaskSelect.Enabled = false;
                TaskSelect.Enabled = false;
                LS_Time = DateTime.Now.ToFileTimeUtc();
                STWStart.Text = G_Lang[Lang_Index]["Stop Clock"];
            }
            else
            {
                LangChan.Enabled = true;
                STWStart.Text = G_Lang[Lang_Index]["Start Clock"];
            }

            

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (STWStart.Text == G_Lang[Lang_Index]["Stop Clock"])
            {
                Now_Time += (DateTime.Now.ToFileTimeUtc() - LS_Time)/100000;
                LS_Time = DateTime.Now.ToFileTimeUtc();
            }
            STW_Dis.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                Now_Time/6000/60,
                Now_Time/6000%60,
                Now_Time/100%60,
                Now_Time%100
                );
        }

        private void STW_Reset_Click(object sender, EventArgs e)
        {
            

            STW_Dis.Visible = false;
            STW_Reset.Visible = false;
            Help3.Enabled = true;
            GroupTaskSelect.Enabled = true;


            bool Isthere = false;
            foreach (string PP in GroupTaskSelect.Items)
            {
                Isthere = Isthere || (PP == GroupTaskSelect.Text);
            }
            TaskSelect.Enabled = Isthere;
            STWStart.Text = "Start Clock";
            Now_Time = 0;
        }

        public void ChangeState(int SSTATE)
        {
            SState = SSTATE;

            if(G_Lang[Lang_Index].ContainsKey("S" + SState.ToString()))
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

            LangChan.Enabled = (SSTATE != 3 && SSTATE != 4 && SSTATE != 5);
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
            string[] subdirectoryEntries = Directory.GetDirectories(CUR_DIR + "\\Problems\\"+GroupTaskSelect.Text);

            // Loop through them to see if they have any other subdirectories

            foreach (string subdirectory in subdirectoryEntries)

                TaskSelect.Items.Add(subdirectory.Replace(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\", ""));


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
            else if (File.Exists(DirOfSC.Text))
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
                    foreach(string ll in Task_Lang)
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

                    if(!Task_Lang.Contains(LangSelect.Text))LangSelect.Text = Task_Lang[0];
                }


                TimeLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Time"] +": {0:0.0}sec", (float)(Cur_Task_Info.Info_task.TimeLimit / 1000f) * Time_Factor[LangSelect.Text]);
                MemLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Mem"] + ": {0}mb", Cur_Task_Info.Info_task.MemLimit);
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
                DirOfSC.Text = choofdlog.FileName;
            else
                DirOfSC.Text = string.Empty;
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
                if(Res.Text != "[]" && Res.Text != "[Compile Error!!!!]")
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
                    Commenttt.Lines = CommentO;
                    if (Res.Text != "[]" && Res.Text != "[Compile Error!!!!]") Hint_Crt++;
                }
                else
                {
                    MessageBox.Show("เยี่ยมมาก ไอ้ต้าว", "เยี่ยมมาก ไอ้ต้าว");
                }


                    
            }
            else
            {
                Commenttt.Lines = new string[] { };
            }
        }



        private void DirOfSC_TextChanged(object sender, EventArgs e)
        {
            //DEBUG(DirOfSC.Text);
            if (File.Exists(DirOfSC.Text))
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

            if(File.Exists(CUR_DIR+ "\\How To Use OTOGexe.pdf"))
            {
                Process.Start(CUR_DIR + "\\How To Use OTOGexe.pdf");
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            string[] Tuto = new string[] {
            "ญิณดีย์ต้อลลับซู่กาณฉ้วยเหรือ\nกด OK เพื่อไปยังหน้าต่อไป\nกด Cancel เพื่อการออกจากความช่วยเหลือ",
            "โปรแกรมนี้จะเป็นตัวช่วย\nในการตรวจโปรแกรมที่เราเขียน\nว่าถูกหรือแม่นยำหรือไม่\n\nโดยจะรับภาษา c c++ python และ จาวา",
            "โดยสามารถเลือกโจทย์ใน 'Task' ได้\nและดูเนื้อหาโจทย์หรือปัญหาได้โดยการกด 'Doc'",
            "เมื่ออ่านโจทย์เข้าใจแล้วก็เขียนซะ!!\n\nหลักจากเขียนและทดสอบแล้วก็ลองตรวจเลย",
            "เวลาตรวจให้เลือกไฟล์ที่ต้องการตรวจ จากนั้นก็กด Submit",
            "ถ้าไม่มีข้อผิดพลาดก็จะได้ผลตรวจ",
            "หากมีคำถามก็ถามมาที่ หา่้เ้ฟนด้รเ้"
            };

            string[] Titl = new string[] {
            "ญิณดีย์ต้อลลับ",
            "มันคืออะไร!!",
            "คำถามล่ะ!",
            "โจทย์",
            "ตรวจจจ",
            "Compile...",
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
                else if(GroupTaskSelect.Text.Contains("EN811300"))
                {
                    Warning.Text = "พึ่งระลึกไว้เสมอว่า ตัวทดสอบนี้ ไม่เหมือน Autolab";
                }

                

                TaskSubed.Text = "["+GroupTaskSelect.Text+"]"+TaskSelect.Text;
                FileSubed.Text = DirOfSC.Text;
                SpoilBut.Checked = false;

                if(!Directory.Exists(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text+ "\\CompileSpace"))
                    Directory.CreateDirectory(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace");

                if(TestModeCheck.Checked) DoTesting();
                else DoSubmission();
            }

        }


        


        private void Docu_Click(object sender, EventArgs e)
        {
            string filename = "Meow.pdf";

            if(File.Exists(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\doc.pdf"))
            {
                filename = CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\doc.pdf";
                Process.Start(filename);
            }
            else
            {
                DirectoryInfo d = new DirectoryInfo(CUR_DIR + "\\Problems\\"+ GroupTaskSelect.Text +"\\"+ TaskSelect.Text);
                FileInfo[] Files = d.GetFiles("*.pdf"); //Getting Text files
                if(Files.Length > 0)
                {
                    Process.Start(Files[0].FullName);
                }
                else
                {
                    MessageBox.Show("หา Doc ไม่เจอง่ะ","ไม่เจอ!!!");
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

                    CommentO = ERRRRROR.Replace(CUR_DIR,"..").Split('\n');
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

                INPUTT.Write(string.Join("\n",TestInput.Lines));
                INPUTT.Close();
                long TimeUsed = 0;

            //DEBUG("Stdin Com!");

            int TimeLim = Cur_Task_Info.Info_task.TimeLimit;
            TimeLim = (int)(TimeLim * Time_Factor[Lang_Str]);


            if (!Runnu.WaitForExit(TimeLim))
                {
                    watch.Stop();
                    TimeUsed += watch.ElapsedMilliseconds;
                    Otog_Verdict = G_Lang[Lang_Index]["SJT"];
                    Runnu.Kill();
                    //DEBUG("Time Out!");
                }
                else
                {
                    watch.Stop();
                    TimeUsed += watch.ElapsedMilliseconds;


                if (Runnu.ExitCode != 0)
                    {
                        Otog_Verdict = G_Lang[Lang_Index]["SJR"];
                    }
                    else
                    {
                        StreamReader reader = Runnu.StandardOutput;
                        string output = reader.ReadToEnd();

                        output = output.Replace(((char)10).ToString(), "");

                        Otog_Verdict = "Test Complete";

                        TestOutput.Lines = output.Split((char)13);

                    }


                }




            foreach (string F in DelTo) File.Delete(F);

            Res.Text = "[" + Otog_Verdict + "]";
            if (Otog_Verdict == "Test Complete")
            {
                Res.ForeColor = Color.FromArgb(87 / 2, 229 / 2, 87 / 2);
                CommentO = new string[] { "Test Ok :) YEY!" };
                STWStart.Text = "Start Clock";
                Poi.Text = "100";
            }
            else
            {
                Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);
                CommentO = Test_Comment.Split('\n');
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

            if(LangSelect.Text != "Java") NewFile += "Src" + "." + SPL2[1];
            else
            {
                DelTo.Enqueue(NewFile+ SPL2[0]+".class");
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
                    MessageBox.Show(G_Lang[Lang_Index]["CE"], "ERROR!");
                    Res.Text = "[Compile Error!!!!]";
                    Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);

                    CommentO = ERRRRROR.Replace(CUR_DIR, "..").Split('\n');
                    SpoilBut.Checked = true;
                    File.Delete(NewFile);
                    Poi.Text = "0";
                    return;
                }

                

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

            //Part Judge
            ChangeState(4);


            int Test_case = 1;
            int n_Test_case = 1;
            float Scoring = 0;
            float Max_Scoring = 0;
            long TimeUsed = 0;

            int TimeLim = Cur_Task_Info.Info_task.TimeLimit;
            TimeLim = (int)(TimeLim * Time_Factor[Lang_Str]);


            Test_case = 1;
            string Otog_Verdict = "";
            string Test_Comment = "";
            string Over_Verdict = "";
            int WT = -1;


            Cur_Task_Info.Judge_Task.MainCMD = JsonConverting(Cur_Task_Info.Judge_Task.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
            Cur_Task_Info.Judge_Task.ArgsCMD = JsonConverting(Cur_Task_Info.Judge_Task.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");

            while (Test_case <= MAX_TESTCASE)
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
                //DEBUG(output);


                string[] VeryOut = output.Split(';');



                if (VeryOut.Length != 5)
                {
                    Otog_Verdict += "!";
                    if (Test_Comment == "")
                    {
                        Test_Comment = "KSES said "+G_Lang[Lang_Index]["PE"];
                    }
                    if (Over_Verdict == "")
                    {
                        Over_Verdict = G_Lang[Lang_Index]["SJE"] + Test_case;
                    }
                    Test_case++;
                    continue;
                }


                if (VeryOut[0] == "E")
                {
                    break;
                }


                if (Test_Comment == "")
                {
                    if (VeryOut[0] == "T") {
                        Over_Verdict = G_Lang[Lang_Index]["SJT"] + Test_case;
                        Test_Comment = string.Format(G_Lang[Lang_Index]["JT"], Test_case);
                    }
                    else if (VeryOut[0] == "X")
                    {
                        Over_Verdict = G_Lang[Lang_Index]["SJR"] + Test_case;
                        Test_Comment = string.Format(G_Lang[Lang_Index]["JR"], Test_case);
                    }
                    else if (VeryOut[0] == "S")
                    {
                        Test_Comment = string.Format(G_Lang[Lang_Index]["JS"], Test_case);
                    }
                        
                    else if (VeryOut[0] == "H")
                    {
                        Over_Verdict = G_Lang[Lang_Index]["SJH"] + Test_case;
                        Test_Comment = string.Format(G_Lang[Lang_Index]["JH"], Test_case, VeryOut[4]);
                    }
                    else if (VeryOut[0] == "!")
                    {
                        Over_Verdict = G_Lang[Lang_Index]["SJE"] + Test_case;
                        Test_Comment = "KSES said " + G_Lang[Lang_Index]["PE"];
                    }
                    else if (VeryOut[0] == "-")
                    {
                        Over_Verdict = G_Lang[Lang_Index]["SJW"] + Test_case;
                        if (Cur_Task_Info.Judge_Task.ArgsCMD == JsonConverting("\"<<Cur_Dir>>\\StdJudge\\judge.py\"", NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe"))
                        {
                            //Std Judge
                            if(WT==-1)WT = Test_case;
                        }
                        else
                        {
                            Test_Comment = string.Format(G_Lang[Lang_Index]["JWAC"], Test_case, VeryOut[4]);
                        }
                    }
                }


                Scoring += float.Parse(VeryOut[2], CultureInfo.InvariantCulture.NumberFormat);
                Max_Scoring += float.Parse(VeryOut[3], CultureInfo.InvariantCulture.NumberFormat);

                n_Test_case = Test_case;
                Test_case++;
                Otog_Verdict += VeryOut[0];

                TimeUsed += (int)(float.Parse(VeryOut[1], CultureInfo.InvariantCulture.NumberFormat));
                


            }
            


            if(WT != -1)
            {



                

                Runnu.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_ComRun[Lang_Str].Runner.MainCMD,Cur_Task_Info.Info_ComRun[Lang_Str].Runner.ArgsCMD);
                Runnu.StartInfo.CreateNoWindow = true;
                Runnu.StartInfo.UseShellExecute = false;
                Runnu.StartInfo.RedirectStandardError = true;
                Runnu.StartInfo.RedirectStandardInput = true;
                Runnu.StartInfo.RedirectStandardOutput = true;

                Runnu.Start();
                //DEBUG("Stdin!");
                StreamWriter INPUTT = Runnu.StandardInput;

                string IIIN = File.ReadAllText(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\" + WT.ToString() + ".in");

                INPUTT.Write(IIIN);
                INPUTT.Close();


                Runnu.WaitForExit();



                if (Runnu.ExitCode != 0)
                {
                    Test_Comment = string.Format(G_Lang[Lang_Index]["JW"], Test_case)+"\n\n????????";
                }
                else
                {
                    StreamReader reader = Runnu.StandardOutput;
                    string output = reader.ReadToEnd().Trim(new Char[] { ' ', ((char)10), (char)13 });

                    string Sol = File.ReadAllText(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\" + WT.ToString() + ".sol").Trim(new Char[] { ' ', '\n' }); ;

                    output = output.Replace(((char)10).ToString(), "");


                    string[] Outs = output.Split((char)13);
                    string[] Sols = Sol.Split((char)13);


                    if (Outs.Length != Sols.Length)
                    {
                        Test_Comment = string.Format(G_Lang[Lang_Index]["JWAL"], Sols.Length, Outs.Length, WT, string.Join("\n", Sols), string.Join("\n", Outs), IIIN);
                    }
                    else
                    {

                        for(int i=0;i< Outs.Length; i++)
                        {
                            Outs[i] = Outs[i].Trim(new Char[] { ' ', '\n' });
                            Sols[i] = Sols[i].Trim(new Char[] { ' ', '\n' });
                            
                            if(Outs[i] != Sols[i])
                            {
                                Test_Comment = string.Format(G_Lang[Lang_Index]["JWA"],i+1, Sols[i], Outs[i], WT, string.Join("\n", Sols), string.Join("\n", Outs), IIIN);
                                break;
                            }

                        }


                    }


                }




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

            if(Test_case <= 20) Res.Text = "[" + Otog_Verdict + "]";
            else Res.Text = "[" + Over_Verdict + "]";
            if (Test_Comment == "")
            {
                Res.ForeColor = Color.FromArgb(87 / 2, 229 / 2, 87 / 2);
                CommentO = new string[]{"Test Ok :) YEY!"};
                STWStart.Text = "Start Clock";
            }
            else
            {
                Res.ForeColor = Color.FromArgb(255/2, 103 / 2, 103 / 2);
                CommentO = Test_Comment.Split('\n');
            }


            Poi.Text = string.Format("{0:0.##}", (float)(Scoring) /n_Test_case*100);
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
            MEOW = MEOW.Replace("<<Cur_Dir>>", CUR_DIR);
            MEOW = MEOW.Replace("<<Cur_Src>>", Cur_Src);
            MEOW = MEOW.Replace("<<Cur_Run_Exe>>", Cur_RunExe);
            MEOW = MEOW.Replace("<<Cur_Problem>>", CUR_DIR+ "\\Problems\\" + GroupTaskSelect.Text+"\\"+ TaskSelect.Text);
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

            DirOfSC.Text = "";
        }

        public int Lang_Index = 0;

        public void Use_Lang(int index)
        {
            Lang_Index = index;


            LangChan.Text = G_Lang[(index+1)%G_Lang.Count]["Call_Lang"];
            CheckBut.Text = G_Lang[index]["Check Update"];
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

            MoreTask.Text = G_Lang[index]["More Task"];
            Help3.Text = G_Lang[index]["Help"];

            if (TimeLimitlabel.Visible)
            {
                string Meow = LangSelect.Text;
                float Fac = Time_Factor[Meow];
                TimeLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Time"] + ": {0:0.0}sec", (float)(Cur_Task_Info.Info_task.TimeLimit / 1000f)*Fac);
                MemLimitlabel.Text = string.Format(G_Lang[Lang_Index]["Mem"] + ": {0}mb", Cur_Task_Info.Info_task.MemLimit);
            }

            ChangeState(SState);

        }

        private void LangChan_Click(object sender, EventArgs e)
        {
            Use_Lang((Lang_Index+1)%G_Lang.Count);
        }

        private void MoreTask_Click(object sender, EventArgs e)
        {
            if(File.Exists(CUR_DIR + "\\ProblemDownload.exe"))
            {
                Process.Start(CUR_DIR + "\\ProblemDownload.exe");
            }
            else
            {
                MessageBox.Show("ไม่พบโปรแกรมดาวโหลดโจทย์", "เกิดข้อผิดพลาด");
            }
            
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

        public Com_Run(string com_exe,string com_args,string run_exe,string run_args)
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
                    {"C++",new Com_Run("\"<<Cur_Dir>>\\Compiler\\MinGW\\bin\\g++.exe\"", "-O2 -std=c++17 \"<<Cur_Src>> \" -o \"<<Cur_Run_Exe>>\"","\"<<Cur_Run_Exe>>\"", "\"\"")},
                    {"Python",new Com_Run("\"<<Cur_Dir>>\\Compiler\\Python\\python.exe\"", "-m py_compile \"<<Cur_Src>>\"","\"<<Cur_Dir>>\\Compiler\\Python\\python.exe\"", "\"<<Cur_Src>>\"")},
                    {"Java",new Com_Run("\"<<Cur_Dir>>\\Compiler\\Java\\bin\\javac.exe\"", "\"<<Cur_Src>>\"","\"<<Cur_Dir>>\\Compiler\\Java\\bin\\java.exe\"", "\"<<Cur_Src>>\"")},
                };
            }
        }

    };
}
