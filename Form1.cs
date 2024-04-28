namespace _2024_GUI_GuessNumber
{
    public partial class Form1 : Form
    {
        private XaXbEngine xaxb; //�إ߹C����������
        private int counter; //�إ߭p�ƾ����
        public Form1()
        {
            InitializeComponent();
            xaxb = new XaXbEngine(); //��l�ƹC������
            counter = 0; //��l���q���Ʀr��0
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String userNum = textBox1.Text.Trim(); //���o�ϥΪ̿�J���Ʀr
            if (xaxb.IsLegal(userNum)) //�ˬd��J���Ʀr�ϧ_�X�k
            {
                counter++; //�q�����ƥ[1
                String result = xaxb.GetResult(userNum); //���o�q�����G
                textBox2.Text += $"{userNum} : {result}, �q������: {counter}" + Environment.NewLine; //�b�T���椤��ܲq�����G�M����
                if (result == "3A0B") //�q���F
                {
                    textBox2.Text += "���ߧA�A�q��F!"; //��ܮ��߰T��
                    DialogResult result1 = MessageBox.Show("�O�_�n�����{���H", "���ߧA�A�q��F!", MessageBoxButtons.YesNo); //���X�O�_�n�����{�����ﶵ
                    if (result1 == DialogResult.Yes) //�p�G�ϥΪ̿�ܵ����{��
                    {
                        Application.Exit(); //�����{��
                    }
                    button1.Enabled = false; //���q�Ʀr���s�L�k�A�I��
                }
            }
            else
            {
                textBox2.Text += "��J����ƭ���, �Ϊ��פ���!! �Э��s��J!!" + Environment.NewLine; //���ܨϥΪ̭��s��J
            }
            textBox1.Clear(); //�M�ŨϥΪ̿�J���e
        }
    }
    public class XaXbEngine
    {
        string luckynum; //�s�x���B�Ʀr
        public XaXbEngine()
        {
            Random random = new Random(); //��l��random����
            int[] tem = new int[3]; //�إߪ��׬�3����ư}�C
            tem[0] = random.Next(0, 9); //�H������0��9�������Ʀr
            tem[1] = random.Next(0, 9);
            tem[2] = random.Next(0, 9);
            while (tem[0] == tem[1] ^ tem[1] == tem[2] ^ tem[0] == tem[2]) //�T�O�Ʀr������
            {
                tem[1] = random.Next(0, 9);
                tem[2] = random.Next(0, 9);
            }
            luckynum = $"{tem[0]}{tem[1]}{tem[2]}"; //�N�H�����ͪ��Ʀr�ഫ���r����x�s
        }
        public bool SetLuckyNumber(String newLuckyNum)
        {
            if (IsLegal(newLuckyNum)) //�ˬd�s�����B�Ʀr�O�_�X�k
            {
                this.luckynum = newLuckyNum; //�]�m�s�����B�Ʀr
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetLuckyNumber()
        {
            return this.luckynum; //�^�ǩ��B�Ʀr
        }
        public Boolean IsLegal(String theNumber) //�ˬd�Ʀr�O�_�X�k����k
        {
            char[] tem = theNumber.ToCharArray(); // �N�r���ഫ���r���}�C
            if (tem.Length == 3) //�p�G�r����׬�3
            {
                if (tem[0] != tem[1] ^ tem[1] != tem[2] ^ tem[0] != tem[2]) //�p�G�Ʀr������
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
        public string GetResult(String userNumber) //�o��q�����G����k
        {
            char[] user = userNumber.ToCharArray(); //�N�ϥΪ̿�J���Ʀr�ഫ���r���}�C
            char[] ans = this.luckynum.ToCharArray(); //�N���B�Ʀr�ഫ���r���}�C
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
                            a++; //�p�G�Ʀr�ۦP��m�]�ۦPa+1
                        }
                        else
                        {
                            b++; //�p�G�Ʀr�ۦP��m���ۦPb+1
                        }
                    }
                }
            }
            return $"{a}A{b}B"; //�^�ǲq�����G
        }
        public Boolean IsGameover(String userNumber) //�ˬd�C���O�_��������k
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
