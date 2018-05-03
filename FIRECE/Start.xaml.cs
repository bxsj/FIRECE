using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FIRECE
{
    //棋子大小：25*25
    //格子大小：40*40
    //棋盘大小：520*520,14条线，每两条间距40形成13格
    //board存储：0-12
    //禁点坐标：（2,2）（1,5）（5,1）（3,9）（9,3）（7,7）（6,10）（10，6）（11,11）

    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }

        int[,] board = new int[13, 13];//0 means null,1 means ice,2 means fire,3 means stone
        int nowTurn = 1;//0 means ice,1 means fire
        int stage = 0;//0 means pick up piece, 1 means choosing place to move
        int tempx, tempy = 0;//used for mark the board
        int has_move = 0;//0 means not move
        int has_click = 0;
        int fire_death = 0;
        int ice_death = 0;
        static int number_of_ice = 15;
        static int number_of_fire = 6;
        private int x, y = 0;
        int[] ice_alive = new int[number_of_ice];//1 means alive,0 means dead
        int[] fire_alive = new int[number_of_fire];
        

        Rectangle r = new Rectangle();
        Rectangle i1 = new Rectangle();
        Rectangle i2 = new Rectangle();
        Rectangle i3 = new Rectangle();
        Rectangle i4 = new Rectangle();
        Rectangle i5 = new Rectangle();
        Rectangle i6 = new Rectangle();
        Rectangle i7 = new Rectangle();
        Rectangle i8 = new Rectangle();
        Rectangle i9 = new Rectangle();
        Rectangle i10 = new Rectangle();
        Rectangle i11 = new Rectangle();
        Rectangle i12 = new Rectangle();
        Rectangle i13 = new Rectangle();
        Rectangle i14 = new Rectangle();
        Rectangle i15 = new Rectangle();
        Rectangle f1 = new Rectangle();
        Rectangle f2 = new Rectangle();
        Rectangle f3 = new Rectangle();
        Rectangle f4 = new Rectangle();
        Rectangle f5 = new Rectangle();
        Rectangle f6 = new Rectangle();
        
        
        void initialize_data()
        {
            for(int i = 0; i < number_of_ice; ++i)
            {
                ice_alive[i] = 1;
            }
            for(int i = 0; i < number_of_fire; ++i)
            {
                fire_alive[i] = 1;
            }
        }
        void turn_dead()
        {

        }
        bool isObeyTheKill()
        {
            return false;
        }
        int death_fire_number()//double = int 存疑
        {
            if ((x == (Canvas.GetLeft(f1) - 7.5) / 40) && (y == (Canvas.GetTop(f1) - 7.5) / 40))
            {
                return 1;
            }
            else if ((x == (Canvas.GetLeft(f2) - 7.5) / 40) && (y == (Canvas.GetTop(f2) - 7.5) / 40))
            {
                return 2;
            }
            else if ((x == (Canvas.GetLeft(f3) - 7.5) / 40) && (y == (Canvas.GetTop(f3) - 7.5) / 40))
            {
                return 3;
            }
            else if ((x == (Canvas.GetLeft(f4) - 7.5) / 40) && (y == (Canvas.GetTop(f4) - 7.5) / 40))
            {
                return 4;
            }
            else if ((x == (Canvas.GetLeft(f5) - 7.5) / 40) && (y == (Canvas.GetTop(f5) - 7.5) / 40))
            {
                return 5;
            }
            else if ((x == (Canvas.GetLeft(f6) - 7.5) / 40) && (y == (Canvas.GetTop(f6) - 7.5) / 40))
            {
                return 6;
            }
            else
            {
                return 0;
            }
                
        }

        int death_ice_number()
        {
            if ((x == (Canvas.GetLeft(i1) - 7.5) / 40) && (y == (Canvas.GetTop(i1) - 7.5) / 40))
            {
                return 1;
            }
            else if ((x == (Canvas.GetLeft(i2) - 7.5) / 40) && (y == (Canvas.GetTop(i2) - 7.5) / 40))
            {
                return 2;
            }
            else if ((x == (Canvas.GetLeft(i3) - 7.5) / 40) && (y == (Canvas.GetTop(i3) - 7.5) / 40))
            {
                return 3;
            }
            else if ((x == (Canvas.GetLeft(i4) - 7.5) / 40) && (y == (Canvas.GetTop(i4) - 7.5) / 40))
            {
                return 4;
            }
            else if ((x == (Canvas.GetLeft(i5) - 7.5) / 40) && (y == (Canvas.GetTop(i5) - 7.5) / 40))
            {
                return 5;
            }
            else if ((x == (Canvas.GetLeft(i6) - 7.5) / 40) && (y == (Canvas.GetTop(i6) - 7.5) / 40))
            {
                return 6;
            }
            else if ((x == (Canvas.GetLeft(i7) - 7.5) / 40) && (y == (Canvas.GetTop(i7) - 7.5) / 40))
            {
                return 7;
            }
            else if ((x == (Canvas.GetLeft(i8) - 7.5) / 40) && (y == (Canvas.GetTop(i8) - 7.5) / 40))
            {
                return 8;
            }
            else if ((x == (Canvas.GetLeft(i9) - 7.5) / 40) && (y == (Canvas.GetTop(i9) - 7.5) / 40))
            {
                return 9;
            }
            else if ((x == (Canvas.GetLeft(i10) - 7.5) / 40) && (y == (Canvas.GetTop(i10) - 7.5) / 40))
            {
                return 10;
            }
            else if ((x == (Canvas.GetLeft(i11) - 7.5) / 40) && (y == (Canvas.GetTop(i11) - 7.5) / 40))
            {
                return 11;
            }
            else if ((x == (Canvas.GetLeft(i12) - 7.5) / 40) && (y == (Canvas.GetTop(i12) - 7.5) / 40))
            {
                return 12;
            }
            else if ((x == (Canvas.GetLeft(i13) - 7.5) / 40) && (y == (Canvas.GetTop(i13) - 7.5) / 40))
            {
                return 13;
            }
            else if ((x == (Canvas.GetLeft(i14) - 7.5) / 40) && (y == (Canvas.GetTop(i14) - 7.5) / 40))
            {
                return 14;
            }
            else if ((x == (Canvas.GetLeft(i15) - 7.5) / 40) && (y == (Canvas.GetTop(i15) - 7.5) / 40))
            {
                return 15;
            }
            else
            {
                return 0;
            }

        }


        bool isObeyTheRule()//unfinished 
        {
              bool flag = true;
            //if (stage == 0)
            //{

            //    if (board[x, y] == 3)
            //    {
            //        MessageBox.Show("can't move the stone!");
            //        flag = false;
            //    }
            //    if ((board[x, y] == 1 && nowTurn == 1))
            //    {
            //        MessageBox.Show("it's time for fire!");
            //        flag = false;
            //    }
            //    if ((board[x, y] == 2 && nowTurn == 0))
            //    {
            //        MessageBox.Show("it's time for ice!");
            //    }
            //}
            //else if (stage == 1)
            //{

            //    if (board[x, y] == 3)
            //    {
            //        MessageBox.Show("can't move to the stone!");
            //        flag = false;
            //    }
            //    if ((board[x, y] == 1 && nowTurn == 0) || (board[x, y] == 2 && nowTurn == 1))
            //    {
            //        MessageBox.Show("can't change the move target!");
            //        flag = false;
            //    }


            //}
            return flag;
        }

        void setBoard()
        {
            for (int i = 0; i < 13; ++i)
            {
                for (int j = 0; j < 13; ++j)
                {
                    board[i, j] = 0;
                }
            }
            setChess(1, 9, 0, i1);
            setChess(1,10,0,i2);
            setChess(1,11,0,i3);
            setChess(2,9,0,i4);
            setChess(2,11,0,i5);
            setChess(3,10,0,i6);
            setChess(3,11,0,i7);
            setChess(6,6,0,i8);
            setChess(9,1,0,i9);
            setChess(9,2,0,i10);
            setChess(10,1,0,i11);
            setChess(10,3,0,i12);
            setChess(11,1,0,i13);
            setChess(11,2,0,i14);
            setChess(11,3,0,i15);
            setChess(3,2,1,f1);
            setChess(2,3,1,f2);
            setChess(3,3,1,f3);
            setChess(9,10,1,f4);
            setChess(10,9,1,f5);
            setChess(10,10,1,f6);

        }
        void setChess(int x,int y,int type, Rectangle rec)//type:0 means ice,1 means fire
        {
            rec.Height = 25;
            rec.Width = 25;
            if (type == 0)
            {
                rec.Fill = Brushes.Blue;
                board[x, y] = 1;
            }
            else
            {
                rec.Fill = Brushes.Red;
                board[x, y] = 2;
            }
            ChessBoard.Children.Add(rec);
            Canvas.SetTop(rec, 40 * y + 7.5);
            Canvas.SetLeft(rec, 40 * x + 7.5);
            
        }
        public void paintx(int x,int y)
        {
            board[x, y] = 3;
            Line xline1 = new Line();
            Line xline2 = new Line();
            xline1.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            xline2.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            xline1.X1 = 40*x+5;
            xline1.X2 = 40*x+35;
            xline1.Y1 = 40*y+5;
            xline1.Y2 = 40*y+35;
            xline2.X1 = 40*x+35;
            xline2.X2 = 40*x+5;
            xline2.Y1 = 40*y+5;
            xline2.Y2 = 40*y+35;
            ChessBoard.Children.Add(xline1);
            ChessBoard.Children.Add(xline2);
        }
        public void paint()
        {
            for (int i = 0; i < 14; ++i)
            {
                Line myline = new Line();
                Line yourline = new Line();
                myline.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                yourline.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                myline.X1 = 0;
                myline.X2 = 520;
                yourline.Y1 = 0;
                yourline.Y2 = 520;
                myline.Y1 = i * 40;
                myline.Y2 = i * 40;
                yourline.X1 = i * 40;
                yourline.X2 = i * 40;
                ChessBoard.Children.Add(myline);
                ChessBoard.Children.Add(yourline);
                paintx(2,2);
                paintx(1,5);
                paintx(5,1);
                paintx(3,9);
                paintx(9,3);
                paintx(7,7);
                paintx(6,10);
                paintx(10,6);
                paintx(11,11);
            }

        }

        void click_chess(Rectangle rec,Point pt)
        {
            if (has_click == 1)
            {
                return;
            }
            if (isObeyTheRule() == false)
            {
                return;
            }
            else if (nowTurn==0&&board[x, y] == 1 && pt.X > Canvas.GetLeft(rec)-7.5 && pt.X < Canvas.GetLeft(rec) + 32.5 && pt.Y > Canvas.GetTop(rec)-7.5 && pt.Y < Canvas.GetTop(rec) + 32.5)
            {
                has_click = 1;
                r = rec;
                rec.Fill = Brushes.LightSkyBlue;
                stage = 1;
                board[x, y] = 0;
                tempx = x;
                tempy = y;
                

            }
            else if(nowTurn==1&&board[x,y]==2&& pt.X > Canvas.GetLeft(rec) - 7.5 && pt.X < Canvas.GetLeft(rec) + 32.5 && pt.Y > Canvas.GetTop(rec) - 7.5 && pt.Y < Canvas.GetTop(rec) + 32.5)
            {
                has_click = 1;
                r = rec;
                rec.Fill = Brushes.Tomato;
                stage = 1;
                board[x, y] = 0;
                tempx = x;
                tempy = y;
                
            }
        } 
        
        void move_chess(Rectangle rec,Point pt,int type,int id)//type:0 means ice, 1 means fire
        {
            
            if (has_move == 1)
            {
                return;
            }
            //对于死亡id不进行运算，相当于把棋子从棋盘上面清除
            if (nowTurn == 0)
            {
                if (ice_alive[id-1] == 0)
                {
                    return;
                }
            }
            else if (nowTurn == 1)
            {
                if (fire_alive[id-1] == 0)
                {
                    return;
                }
            }

            //先判断是否违反规则，再判断是否完成击杀
            if (isObeyTheRule() == false)
            {
                if (r == rec && type == 0)
                {
                    rec.Fill = Brushes.Blue;
                    stage = 0;
                    board[tempx, tempy] = 1;

                }
                if (r == rec && type == 1)
                {
                    rec.Fill = Brushes.Red;
                    stage = 0;
                    board[tempx, tempy] = 2;
                }
            }
            if (isObeyTheKill())
            {
                if (nowTurn == 0)//ice kill fire
                {
                    fire_alive[death_fire_number()] = 0;
                    //未完成清除rectangle的外在显示
                }
                else//fire kill ice
                {
                    ice_alive[death_ice_number()] = 0;
                }
            }
            if (r == rec&&type==0)
            {
                has_move = 1;
                rec.Fill = Brushes.Blue;
                Canvas.SetTop(rec, 40 * y + 7.5);
                Canvas.SetLeft(rec, 40 * x + 7.5);
                stage = 0;
                board[x, y] = 1;
                nowTurn = 1;
            }
            else if (r == rec && type == 1)
            {
                has_move = 1;
                rec.Fill = Brushes.Red;
                Canvas.SetTop(rec, 40 * y + 7.5);
                Canvas.SetLeft(rec, 40 * x + 7.5);
                stage = 0;
                board[x, y] = 2;
                nowTurn = 0;
            }
        }
        private void ChessBoard_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
            Point pt = e.GetPosition(ChessBoard);
            x = (int)pt.X / 40;
            y = (int)pt.Y / 40;
            if (stage == 0)
            {
                has_click = 0;
                if (nowTurn == 0)
                {
                    click_chess(i1, pt);
                    click_chess(i2, pt);
                    click_chess(i3, pt);
                    click_chess(i4, pt);
                    click_chess(i5, pt);
                    click_chess(i6, pt);
                    click_chess(i7, pt);
                    click_chess(i8, pt);
                    click_chess(i9, pt);
                    click_chess(i10, pt);
                    click_chess(i11, pt);
                    click_chess(i12, pt);
                    click_chess(i13, pt);
                    click_chess(i14, pt);
                    click_chess(i15, pt);
                }
                else if (nowTurn == 1)
                {
                    click_chess(f1, pt);
                    click_chess(f2, pt);
                    click_chess(f3, pt);
                    click_chess(f4, pt);
                    click_chess(f5, pt);
                    click_chess(f6, pt);
                }


            }
            else if(stage == 1)
            {

                has_move = 0;
                if (nowTurn == 0)
                {
                    move_chess(i1, pt, 0,1);
                    move_chess(i2, pt, 0,2);
                    move_chess(i3, pt, 0,3);
                    move_chess(i4, pt, 0,4);
                    move_chess(i5, pt, 0,5);
                    move_chess(i6, pt, 0,6);
                    move_chess(i7, pt, 0,7);
                    move_chess(i8, pt, 0,8);
                    move_chess(i9, pt, 0,9);
                    move_chess(i10, pt, 0,10);
                    move_chess(i11, pt, 0,11);
                    move_chess(i12, pt, 0,12);
                    move_chess(i13, pt, 0,13);
                    move_chess(i14, pt, 0,14);
                    move_chess(i15, pt, 0,15);
                }
                else
                {
                    move_chess(f1, pt, 1,1);
                    move_chess(f2, pt, 1,2);
                    move_chess(f3, pt, 1,3);
                    move_chess(f4, pt, 1,4);
                    move_chess(f5, pt, 1,5);
                    move_chess(f6, pt, 1,6);
                }



            }
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Begin_Click(object sender, RoutedEventArgs e)
        {
            initialize_data();
            setBoard();
            paint();
        }
    }
}
