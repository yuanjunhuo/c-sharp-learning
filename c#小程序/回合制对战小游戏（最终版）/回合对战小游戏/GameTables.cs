using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 回合对战小游戏
{
    public class GameTables//游戏桌类
    {
        public User[] players { get; set; }//本桌用户
        public int hp1;//玩家们的血量和能量
        public int mp1;
        public int hp2;
        public int mp2;
        public int nextplayer = 0;//下一位玩家
        public int count = 0;//2次为一轮
        public int[] Ops = new int[2];//保存玩家操作编号
        public string[] skills = new string[2];//保存玩家操作名称

        public GameTables()//初始化游戏桌
        {
            players = new User[2];
            Resetgames();
            Rules.Initialise();
        }
        public void Resetgames()
        {
            hp1 = 20; mp1 = 3;
            hp2 = 20; mp2 = 3;

        }
        public void DothisOrder(int side, int Num, string skillname)
        {
            if (side == 0)
            {
                if (Rules.operations[Num].MP < 0)//判断能量是否够此操作
                {
                    if (Math.Abs(Rules.operations[Num].MP) > mp1)
                    {
                        players[0].callback.Showmpnot();
                        return;
                    }

                }
            }
            else
            {
                if (Rules.operations[Num].MP < 0)//判断能量是否够此操作
                {
                    if (Math.Abs(Rules.operations[Num].MP) > mp2)
                    {
                        players[1].callback.Showmpnot();
                        return;
                    }

                }
            }
            
                count++;
                bool isfishone = finishOne();
                players[0].callback.ShowOpertion(side, isfishone);
                players[1].callback.ShowOpertion(side, isfishone);
                Ops[side] = Num;
                skills[side] = skillname;
                if (count == 0)//重置count说明一回合结束
                {

                    Rules.Judge(ref hp1, ref mp1, ref hp2, ref mp2, Rules.operations[Ops[0]], Rules.operations[Ops[1]]);
                    int iswin = isWin();
                    if (iswin != 0)
                    {
                        players[0].callback.ShowWin(iswin);
                        players[1].callback.ShowWin(iswin);
                    }
                    players[0].callback.ShowResult(skills[0], skills[1], hp1, hp2, mp1, mp2);
                    players[1].callback.ShowResult(skills[0], skills[1], hp1, hp2, mp1, mp2);
                    



            }
            }
            public bool finishOne()//是否完成一轮
            {
                if (count == 2)
                {
                    count = 0;
                    return true;

                }
                else
                {
                    return false;
                }

            }
        public int isWin()//判断输赢
        {
            if (hp1 > 0 && hp2 > 0)
            {
                if (skills[0] == "能量倾泻" && skills[1] == "能量倾泻")
                    return 3;
                else if (skills[0] == "能量倾泻")
                    return 1;
                else if (skills[1] == "能量倾泻")
                    return 2;
                else
                    return 0;
                
            }
            else
            {
                if (hp1 <= 0 && hp2 <= 0)
                    return 3;
                else if (hp1 <= 0)
                    return 2;

                else if (hp2 <= 0)
                    return 1;
                else
                    return 0;
            }
        }
        
        }
    
    }
