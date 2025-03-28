namespace WhatIsTasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

        }

        Thread threadCounter;
        private void buttonThreadStart_Click(object sender, EventArgs e)
        {
            threadCounter = new Thread(() =>
            {
                for (int i = 0; i < 10000; i++)
                {

                    labelThreadStart.Text = i.ToString();
                }
            });
            threadCounter.Start();

            MessageBox.Show("Bu ne zaman çalışır?");

        }

        private async void buttonTask_Click(object sender, EventArgs e)
        {
           await Task.Run(() =>
            {
                for (int i = 1; i <= 10000; i++)
                {
                    labelTask.Text = i.ToString();
                    progressBar1.Value = i / 100;
                }
            });

            MessageBox.Show("İşlem tamamlandı?");
        }
    }
}
