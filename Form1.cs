namespace _2024_GUI_GuessNumber
{
    public partial class Form1 : Form
    {
        private XaXbEngine xaxb; //建立遊戲引擎物件
        private int counter; //建立計數器欄位
        public Form1()
        {
            InitializeComponent();
            xaxb = new XaXbEngine(); //初始化遊戲引擎
            counter = 0; //初始的猜測數字為0
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String userNum = textBox1.Text.Trim(); //取得使用者輸入的數字
            if (xaxb.IsLegal(userNum)) //檢查輸入的數字使否合法
            {
                counter++; //猜測次數加1
                String result = xaxb.GetResult(userNum); //取得猜測結果
                textBox2.Text += $"{userNum} : {result}, 猜測次數: {counter}" + Environment.NewLine; //在訊息欄中顯示猜測結果和次數
                if (result == "3A0B") //猜中了
                {
                    textBox2.Text += "恭喜你，猜對了!"; //顯示恭喜訊息
                    DialogResult result1 = MessageBox.Show("是否要結束程式？", "恭喜你，猜對了!", MessageBoxButtons.YesNo); //跳出是否要結束程式的選項
                    if (result1 == DialogResult.Yes) //如果使用者選擇結束程式
                    {
                        Application.Exit(); //關閉程式
                    }
                    button1.Enabled = false; //讓猜數字按鈕無法再點擊
                }
            }
            else
            {
                textBox2.Text += "輸入的資料重複, 或長度不對!! 請重新輸入!!" + Environment.NewLine; //提示使用者重新輸入
            }
            textBox1.Clear(); //清空使用者輸入內容
        }
    }
    public class XaXbEngine
    {
        string luckynum; //存儲幸運數字
        public XaXbEngine()
        {
            Random random = new Random(); //初始化random物件
            int[] tem = new int[3]; //建立長度為3的整數陣列
            tem[0] = random.Next(0, 9); //隨機產生0到9之間的數字
            tem[1] = random.Next(0, 9);
            tem[2] = random.Next(0, 9);
            while (tem[0] == tem[1] ^ tem[1] == tem[2] ^ tem[0] == tem[2]) //確保數字不重複
            {
                tem[1] = random.Next(0, 9);
                tem[2] = random.Next(0, 9);
            }
            luckynum = $"{tem[0]}{tem[1]}{tem[2]}"; //將隨機產生的數字轉換成字串並儲存
        }
        public bool SetLuckyNumber(String newLuckyNum)
        {
            if (IsLegal(newLuckyNum)) //檢查新的幸運數字是否合法
            {
                this.luckynum = newLuckyNum; //設置新的幸運數字
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetLuckyNumber()
        {
            return this.luckynum; //回傳幸運數字
        }
        public Boolean IsLegal(String theNumber) //檢查數字是否合法的方法
        {
            char[] tem = theNumber.ToCharArray(); // 將字串轉換成字元陣列
            if (tem.Length == 3) //如果字串長度為3
            {
                if (tem[0] != tem[1] ^ tem[1] != tem[2] ^ tem[0] != tem[2]) //如果數字不重複
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public string GetResult(String userNumber) //得到猜測結果的方法
        {
            char[] user = userNumber.ToCharArray(); //將使用者輸入的數字轉換成字元陣列
            char[] ans = this.luckynum.ToCharArray(); //將幸運數字轉換成字元陣列
            int a = 0;
            int b = 0;
            for (int i = 0; i < user.Length; i++)
            {
                for (int j = 0; j < ans.Length; j++)
                {
                    if (user[i] == ans[j])
                    {
                        if (i == j)
                        {
                            a++; //如果數字相同位置也相同a+1
                        }
                        else
                        {
                            b++; //如果數字相同位置不相同b+1
                        }
                    }
                }
            }
            return $"{a}A{b}B"; //回傳猜測結果
        }
        public Boolean IsGameover(String userNumber) //檢查遊戲是否結束的方法
        {
            if (GetResult(userNumber) == "3A0B")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
