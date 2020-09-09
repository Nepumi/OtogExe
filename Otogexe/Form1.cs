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

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

using Newtonsoft.Json;



namespace Otogexe
{

    


    public partial class Otog : Form
    {


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

            
        }


        //Stopwatch
        public long Now_Time = 0;
        private long LS_Time = 0;


        private void Form1_Activated(object sender, System.EventArgs e)
        {
            ChangeState(SState);

            //DEBUG(CUR_DIR);
        }


        private void STWStart_Click(object sender, EventArgs e)
        {
            STW_Reset.Visible = true;
            STW_Dis.Visible = true;

            Help3.Enabled = false;
            Help4.Enabled = false;

            if (STWStart.Text == "Start Clock")
            {
                GroupTaskSelect.Enabled = false;
                TaskSelect.Enabled = false;
                LS_Time = DateTime.Now.ToFileTimeUtc();
                STWStart.Text = "Stop Clock";
            }
            else
            {
                STWStart.Text = "Start Clock";
            }

            

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (STWStart.Text == "Stop Clock")
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
            Help4.Enabled = true;
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
            switch (SState)
            {
                case 0: Sstate.Text = "Ready!"; break;
                case 1: Sstate.Text = "Select Task"; break;
                case 2: Sstate.Text = "Select file"; break;
                case 3: Sstate.Text = "Compile..."; break;
                case 4: Sstate.Text = "Judging..."; break;
                case 5: Sstate.Text = "Testing..."; break;
                case -1: Sstate.Text = "Select Group"; break;
                default: Sstate.Text = "ERROR!"; break;
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
                if (File.Exists(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\Task_Info.Isl"))
                {

                    Cur_Task_Info = JsonConvert.DeserializeObject<Over_Task>(File.ReadAllText(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\Task_Info.Isl"));
                }
                else Cur_Task_Info = new Over_Task();
                TimeLimitlabel.Text = string.Format("Time: {0:0.0}sec", (float)(Cur_Task_Info.Info_task.TimeLimit / 1000f));
                MemLimitlabel.Text = string.Format("Mem: {0}mb", Cur_Task_Info.Info_task.MemLimit);
            }
            TimeLimitlabel.Visible = Isthere;
            MemLimitlabel.Visible = Isthere;




            ChangeState(SState);


        }



        private void DirBro_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "cpp files (*.cpp;*.cc;*.cxx)|*.cpp;*.cc;*.cxx|c files (*.c)|*.c|python files (*.py;)|*.py|java files (*.java)|*.java";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
                DirOfSC.Text = choofdlog.FileName;
            else
                DirOfSC.Text = string.Empty;
        }



        private void SpoilBut_CheckedChanged(object sender, EventArgs e)
        {
            if (SpoilBut.Checked)
            {
                Commenttt.Lines = CommentO;
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
                BarSub.Value = 0;
                if (GroupTaskSelect.Text.Contains("Otog"))
                {
                    Warning.Text = "โจทย์ดังกล่าวได้เอามาจาก Otog.cf ซึ่งตัวทดสอบจะไม่เหมือนกับของจริง!";
                }
                else if(GroupTaskSelect.Text.Contains("EN811300"))
                {
                    Warning.Text = "พึ่งระลึกไว้เสมอว่า ตัวทดสอบนี้ ไม่เหมือน Autolab";
                }

                

                TaskSubed.Text = GroupTaskSelect.Text+"/"+TaskSelect.Text;
                FileSubed.Text = DirOfSC.Text;
                SpoilBut.Checked = false;

                if(TestModeCheck.Checked) DoTesting();
                else DoSubmission();
            }

        }


        


        private void Docu_Click(object sender, EventArgs e)
        {
            string filename = "instructions.pdf";

            if(File.Exists(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\doc.pdf"))
            {
                filename = CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\doc.pdf";
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


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://drive.google.com/drive/folders/1CbYPFDJ_nS1SgycmegMHNi2s8tRFNv7g?usp=sharing");
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

                NewFile += "Src" + "." + SPL2[1];


            }


            File.Copy(FileSubed.Text, NewFile, true);
            DelTo.Enqueue(NewFile);


            if (DirOfSC.Text.EndsWith(".cpp") || DirOfSC.Text.EndsWith(".cc") || DirOfSC.Text.EndsWith(".cxx") ||
                DirOfSC.Text.EndsWith(".c"))
            {
                Process p = new Process();
                if (DirOfSC.Text.EndsWith(".c"))
                {
                    Cur_Task_Info.Info_compiling.C.MainCMD = JsonConverting(Cur_Task_Info.Info_compiling.C.MainCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_compiling.C.ArgsCMD = JsonConverting(Cur_Task_Info.Info_compiling.C.ArgsCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.C.MainCMD = JsonConverting(Cur_Task_Info.Info_running.C.MainCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.C.ArgsCMD = JsonConverting(Cur_Task_Info.Info_running.C.ArgsCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.CPP.MainCMD = JsonConverting(Cur_Task_Info.Info_running.CPP.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.CPP.ArgsCMD = JsonConverting(Cur_Task_Info.Info_running.CPP.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    p.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_compiling.C.MainCMD, Cur_Task_Info.Info_compiling.C.ArgsCMD);
                }
                else
                {
                    Cur_Task_Info.Info_compiling.CPP.MainCMD = JsonConverting(Cur_Task_Info.Info_compiling.CPP.MainCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_compiling.CPP.ArgsCMD = JsonConverting(Cur_Task_Info.Info_compiling.CPP.ArgsCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.CPP.MainCMD = JsonConverting(Cur_Task_Info.Info_running.CPP.MainCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.CPP.ArgsCMD = JsonConverting(Cur_Task_Info.Info_running.CPP.ArgsCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    p.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_compiling.CPP.MainCMD, Cur_Task_Info.Info_compiling.CPP.ArgsCMD);
                }

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
                    MessageBox.Show("Compile Error!!!!", "ERROR!");
                    Res.Text = "[Compile Error!!!!]";
                    Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);

                    CommentO = ERRRRROR.Split('\n');
                    SpoilBut.Checked = true;
                    File.Delete(NewFile);
                    return;
                }

                Runnu.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_running.CPP.MainCMD);

                DelTo.Enqueue(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");

            }
            else if (DirOfSC.Text.EndsWith(".py"))
            {
                Cur_Task_Info.Info_running.PY.MainCMD = JsonConverting(Cur_Task_Info.Info_running.PY.MainCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Cur_Task_Info.Info_running.PY.ArgsCMD = JsonConverting(Cur_Task_Info.Info_running.PY.ArgsCMD, NewFile,CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Runnu.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_running.PY.MainCMD, Cur_Task_Info.Info_running.PY.ArgsCMD);
            }
            else
            {
                MessageBox.Show("ไม่รุจะคอมไพลยังไงอ่ะ", "เหมียว!!!");
                Res.Text = "[!!!!]";
                Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);
                ChangeState(0);
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
                Runnu.Start();
                //DEBUG("Stdin!");
                StreamWriter INPUTT = Runnu.StandardInput;

                INPUTT.Write(string.Join("\n",TestInput.Lines));
                INPUTT.Close();

                //DEBUG("Stdin Com!");

                if (!Runnu.WaitForExit(Cur_Task_Info.Info_task.TimeLimit))
                {
                    Otog_Verdict = "Time Limit Exceed";
                    Runnu.Kill();
                    //DEBUG("Time Out!");
                }
                else
                {
                    if (Runnu.ExitCode != 0)
                    {
                        Otog_Verdict = "Runtime Error";
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

            BarSub.Value = 100;
            Res.Text = "[" + Otog_Verdict + "]";
            if (Otog_Verdict == "Test Complete")
            {
                Res.ForeColor = Color.FromArgb(87 / 2, 229 / 2, 87 / 2);
                CommentO = new string[] { "Test Ok :) YEY!" };
                STWStart.Text = "Start Clock";
            }
            else
            {
                Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);
                CommentO = Test_Comment.Split('\n');
            }


            ChangeState(0);
        }

        public void DoSubmission()
        {

            Queue<string> DelTo = new Queue<string>();

            //Part Compile
            ChangeState(3);
            Process Runnu = new Process();
            string NewFile = "";

            {
                string[] SPL = FileSubed.Text.Split('\\');
                NewFile = CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\";

                string[] SPL2 = SPL[SPL.Length - 1].Split('.');

                NewFile += "Src" + "." + SPL2[1];


            }

           

            File.Copy(FileSubed.Text, NewFile, true);
            DelTo.Enqueue(NewFile);


            if (DirOfSC.Text.EndsWith(".cpp") || DirOfSC.Text.EndsWith(".cc") || DirOfSC.Text.EndsWith(".cxx") ||
                DirOfSC.Text.EndsWith(".c"))
            {
                Process p = new Process();
                if (DirOfSC.Text.EndsWith(".c"))
                {
                    Cur_Task_Info.Info_compiling.C.MainCMD = JsonConverting(Cur_Task_Info.Info_compiling.C.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_compiling.C.ArgsCMD = JsonConverting(Cur_Task_Info.Info_compiling.C.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.C.MainCMD = JsonConverting(Cur_Task_Info.Info_running.C.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.C.ArgsCMD = JsonConverting(Cur_Task_Info.Info_running.C.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.CPP.MainCMD = JsonConverting(Cur_Task_Info.Info_running.CPP.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.CPP.ArgsCMD = JsonConverting(Cur_Task_Info.Info_running.CPP.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    p.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_compiling.C.MainCMD, Cur_Task_Info.Info_compiling.C.ArgsCMD);
                }
                else
                {
                    Cur_Task_Info.Info_compiling.CPP.MainCMD = JsonConverting(Cur_Task_Info.Info_compiling.CPP.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_compiling.CPP.ArgsCMD = JsonConverting(Cur_Task_Info.Info_compiling.CPP.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.CPP.MainCMD = JsonConverting(Cur_Task_Info.Info_running.CPP.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    Cur_Task_Info.Info_running.CPP.ArgsCMD = JsonConverting(Cur_Task_Info.Info_running.CPP.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                    p.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_compiling.CPP.MainCMD, Cur_Task_Info.Info_compiling.CPP.ArgsCMD);
                }

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
                    MessageBox.Show("Compile Error!!!!", "ERROR!");
                    Res.Text = "[Compile Error!!!!]";
                    Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);

                    CommentO = ERRRRROR.Split('\n');
                    SpoilBut.Checked = true;
                    File.Delete(NewFile);
                    return;
                }

                Runnu.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_running.CPP.MainCMD);
                //DEBUG(Cur_Task_Info.Info_running.CPP.MainCMD);
                DelTo.Enqueue(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");

            }
            else if (DirOfSC.Text.EndsWith(".py"))
            {
                Cur_Task_Info.Info_running.PY.MainCMD = JsonConverting(Cur_Task_Info.Info_running.PY.MainCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Cur_Task_Info.Info_running.PY.ArgsCMD = JsonConverting(Cur_Task_Info.Info_running.PY.ArgsCMD, NewFile, CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\CompileSpace\\CppRunner.exe");
                Runnu.StartInfo = new ProcessStartInfo(Cur_Task_Info.Info_running.PY.MainCMD, Cur_Task_Info.Info_running.PY.ArgsCMD);
            }
            else
            {
                MessageBox.Show("ไม่รุจะคอมไพลยังไงอ่ะ", "เหมียว!!!");
                Res.Text = "[!!!!]";
                Res.ForeColor = Color.FromArgb(255 / 2, 103 / 2, 103 / 2);
                ChangeState(0);
                return;
            }

            //Part Judge
            ChangeState(4);


            int Test_case = 1;
            int n_Test_case = 1;

            while (File.Exists(CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\" + Test_case.ToString() + ".in"))
            {
                n_Test_case = Test_case;
                Test_case++;
            }
            Test_case = 1;
            string Otog_Verdict = "";
            string Test_Comment = "";
            while (Test_case <= n_Test_case)
            {
                BarSub.Value = Test_case * 100 / n_Test_case;
                Res.Text = string.Format("[Test #{0}]", Test_case);
                //DEBUG("testCase " + Test_case.ToString());
                //DEBUG(string.Format("[{0}]",Otog_Verdict));
                Res.ForeColor = Color.Black;

                string Test_Dir = CUR_DIR + "\\Problems\\" + GroupTaskSelect.Text + "\\" + TaskSelect.Text + "\\" ;

                Runnu.StartInfo.CreateNoWindow = true;
                Runnu.StartInfo.UseShellExecute = false;
                Runnu.StartInfo.RedirectStandardError = true;
                Runnu.StartInfo.RedirectStandardInput = true;
                Runnu.StartInfo.RedirectStandardOutput = true;
                Runnu.Start();
                //DEBUG("Stdin!");
                StreamWriter INPUTT = Runnu.StandardInput;

                INPUTT.Write(File.ReadAllText(Test_Dir + Test_case.ToString() + ".in"));
                INPUTT.Close();

                //DEBUG("Stdin Com!");

                if (!Runnu.WaitForExit(Cur_Task_Info.Info_task.TimeLimit))
                {
                    Otog_Verdict += "T";
                    if (Test_Comment == "")
                    {
                        Test_Comment = "Time Limit Exceed in case " + Test_case.ToString()+"\n\nโปรแกรมคุณใช้เวลาเกินกว่าที่กำหนดไว้";
                    }
                    Runnu.Kill();
                    //DEBUG("Time Out!");
                }
                else
                {
                    if (Runnu.ExitCode != 0)
                    {
                        Otog_Verdict += "X";
                        if (Test_Comment == "")
                        {
                            if (NewFile.EndsWith(".py"))
                            {
                                StreamReader reader = Runnu.StandardError;
                                string Content = reader.ReadToEnd();
                                MessageBox.Show("Maybe Error!!!!", "ERROR!");
                                Test_Comment = "Maybe Error in case " + Test_case.ToString() + "\nโปรแกรมคุณระเบิดตัวเองทิ้ง\n\n"+ Content;
                            }
                            else
                            {
                                Test_Comment = "Runtime Error in case " + Test_case.ToString() + "\n\nโปรแกรมคุณระเบิดตัวเองทิ้ง";
                            }
                        }
                    }
                    else
                    {
                        StreamReader reader = Runnu.StandardOutput;
                        string output = reader.ReadToEnd();

                        output = output.Replace(((char)10).ToString(), "");

                        //strip
                        int st = 0;
                        for (st = 0; st < output.Length && (output[st] == '\n' || output[st] == ' ' || output[st] == 13); st++) ;
                        int ed = 0;
                        for (ed = output.Length - 1; ed >= 0 && (output[ed] == '\n' || output[ed] == ' ' || output[ed] == 13); ed--) ;
                        if (ed - st + 1 > 0) output = output.Substring(st, ed - st + 1);


                        

                        string Sol = File.ReadAllText(Test_Dir + Test_case.ToString() + ".sol");

                        Sol = Sol.Replace(((char)10).ToString(), "");

                        for (st = 0; st < Sol.Length && (Sol[st] == '\n' || Sol[st] == ' ' || Sol[st] == 13); st++) ;
                        for (ed = Sol.Length - 1; ed >= 0 && (Sol[ed] == '\n' || Sol[ed] == ' ' || Sol[ed] == 13); ed--) ;

                        //DEBUG(string.Format("Out '{0}' as [{1},{2}]", Sol, st, ed));

                        if (ed - st + 1 > 0) Sol = Sol.Substring(st, ed - st + 1);

                        



                        string[] Sols = Sol.Split((char)13);
                        string[] outputs = output.Split((char)13);
                        bool Is_Pass = true;


                        //DEBUG(string.Format("S{0} vs O{1}", Sols.Length, outputs.Length));



                        if (Sols.Length != outputs.Length)
                        {//!Python! Has Mistery charactor
                            Is_Pass = false;
                            Otog_Verdict += "-";
                            if (Test_Comment == "")
                            {
                                Test_Comment = string.Format("Expected {0} lines but yours {1} lines in test case {2}", Sols.Length.ToString(), outputs.Length.ToString(),Test_case.ToString());
                                Test_Comment += string.Format("\n\nคำตอบข้อนี้มี {0} บรรทัด แต่ต่างกับแก!!! มีแค่ {1} บรรทัด", Sols.Length.ToString(), outputs.Length.ToString()); 
                            }
                        }
                        else
                        {
                            int BT = 0;
                            for(BT = 0;BT< Sols.Length; BT++)
                            {
                                string Now_Sol = Sols[BT];
                                string Now_Out = outputs[BT];

                                for (st = 0; st < Now_Sol.Length && (Now_Sol[st] == '\n' || Now_Sol[st] == ' ' || Now_Sol[st] == 13); st++) ;
                                for (ed = Now_Sol.Length - 1; ed >= 0 && (Now_Sol[ed] == '\n' || Now_Sol[ed] == ' ' || Now_Sol[ed] == 13); ed--) ;

                                if (ed - st + 1 > 0) Now_Sol = Now_Sol.Substring(st, ed - st + 1);

                                for (st = 0; st < Now_Out.Length && (Now_Out[st] == '\n' || Now_Out[st] == ' ' || Now_Out[st] == 13); st++) ;
                                for (ed = Now_Out.Length - 1;ed >= 0 && (Now_Out[ed] == '\n' || Now_Out[ed] == ' ' || Now_Out[ed]==13); ed--) ;

                                if(ed - st + 1 > 0) Now_Out = Now_Out.Substring(st, ed - st + 1);

                                //foreach (char x in Now_Out)
                                //{
                                //    DEBUG(string.Format("{0}:{1}", x, (int)x));
                                //}

                                if (Now_Sol != Now_Out)
                                {
                                    Is_Pass = false;
                                    Otog_Verdict += "-";
                                    if (Test_Comment == "")
                                    {
                                        Test_Comment = string.Format("In line {0} Expected '{1}' but yours '{2}' in test case {3}",BT+1, Now_Sol, Now_Out, Test_case.ToString());
                                        Test_Comment += string.Format("\n\nในบรรทัดคำตอบที่ {0} คำตอบคือ '{1}' แต่ต่างกับแก!!! '{2}'",BT+1, Now_Sol, Now_Out);
                                    }
                                    break;
                                }

                            }

                            if (Is_Pass)
                            {
                                Otog_Verdict += "P";
                            }
                        }


                    }

                    
                }

                



                //DEBUG("OUT\n" + output);
                //DEBUG("Ended\n" );
                Test_case++;
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


            Res.Text = "["+Otog_Verdict+"]";
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
            
            
            ChangeState(0);
        }

        private void CheckBut_Click(object sender, EventArgs e)
        {
            try
            {
                string URL = "https://otogexe.firebaseio.com/Now_Ver.json";

                HttpClient Hclient = new HttpClient();
                Hclient.BaseAddress = new Uri(URL);

                // Add an Accept header for JSON format.
                Hclient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = Hclient.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    string dataObjects = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll

                    dataObjects = dataObjects.Split('\"')[1];


                    if (CurVer.Text != dataObjects)
                    {
                        MessageBox.Show("Update Available", "Update!");

                        Process.Start("https://drive.google.com/drive/folders/1CbYPFDJ_nS1SgycmegMHNi2s8tRFNv7g?usp=sharing");
                    }
                    else
                    {
                        MessageBox.Show("It's Up to date\n\nYey", "Meow");
                    }


                    
                }
                else
                {
                    MessageBox.Show("Can\'t Check Update :(", "ERROR!");
                }

                //Make any other calls using HttpClient here.

                //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
                Hclient.Dispose();
            }
            catch
            {
                MessageBox.Show("Can\'t Check Update :(", "ERROR!");
            }
        }


        public string JsonConverting(string X, string Cur_Src, string Cur_RunExe)
        {
            string MEOW = X;
            MEOW = MEOW.Replace("<<Cur_Dir>>", CUR_DIR);
            MEOW = MEOW.Replace("<<Cur_Src>>", Cur_Src);
            MEOW = MEOW.Replace("<<Cur_Run_Exe>>", Cur_RunExe);
            return MEOW;
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

    public class Info_Compiling
    {
        public Mini_CMD C
        {
            get; set;
        } = new Mini_CMD("\"<<Cur_Dir>>\\Compiler\\MinGW\\bin\\gcc.exe\"", "-O2 \"<<Cur_Src>>\" -o \"<<Cur_Run_Exe>>\"");
        public Mini_CMD CPP
        {
            get; set;
        } = new Mini_CMD("\"<<Cur_Dir>>\\Compiler\\MinGW\\bin\\g++.exe\"", "-O2 -std=c++17 \"<<Cur_Src>> \" -o \"<<Cur_Run_Exe>>\"");
        public Mini_CMD PY
        {
            get; set;
        } = new Mini_CMD("cmd.exe", "echo Meow");
        public Mini_CMD JAVA
        {
            get; set;
        } = new Mini_CMD("cmd.exe", "echo Meow");

    };

    public class Info_Running
    {
        public Mini_CMD C
        {
            get; set;
        } = new Mini_CMD("<<Cur_Run_Exe>>", "");
        public Mini_CMD CPP
        {
            get; set;
        } = new Mini_CMD("<<Cur_Run_Exe>>", "");
        public Mini_CMD PY
        {
            get; set;
        } = new Mini_CMD("\"<<Cur_Dir>>\\Compiler\\Python\\python.exe\"", "\"<<Cur_Src>>\"");
        public Mini_CMD JAVA
        {
            get; set;
        } = new Mini_CMD("cmd.exe", "echo Meow");

    };

    public class Over_Task
    {
        public Info_Task Info_task
        {
            set; get;
        } = new Info_Task();

        public Info_Compiling Info_compiling
        {
            set; get;
        } = new Info_Compiling();
        public Info_Running Info_running
        {
            set; get;
        } = new Info_Running();
    };
}
