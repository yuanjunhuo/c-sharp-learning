using System;

namespace 回合对战小游戏
{
    struct Operation   //代表操作的结构体
    {
        public int Num;     //该操作的编号
        public int Type;    //标志信息，表示该操作的类型（1代表恢复能量操作，2代表攻击操作，3代表防御操作，4代表恢复生命值操作）
        public int DPS;     //该操作的伤害值
        public int AC;      //该操作的格挡值
        public int MP;      //该操作的恢复能量值,消耗则为负
        public int HP;      //该操作的恢复血量值
    }
    class Rules
    {
        public static int OpNum = 24;           //操作的数量
        public static Operation[] operations;   //操作结构体数组
        
        public  Rules()
        { 
            Initialise();//为每一个操作赋值
            //int P1HP = 20;          //玩家一初始血量
            //int P1MP = 3;           //玩家一初始能量
            //int P2HP = 20;          //玩家二初始血量
            //int P2MP = 3;           //玩家二初始能量
            //int P1OpNum = 10;        //玩家一本回合的操作编号
            //int P2OpNum = 23;        //玩家二本回合的操作编号
            //Judge(ref P1HP, ref P1MP, ref P2HP, ref P2MP, operations[P1OpNum], operations[P2OpNum]);
            //Console.WriteLine("玩家一本回合结束后的血量"+P1HP);
            //Console.WriteLine("玩家一本回合结束后的能量" + P1MP);
            //Console.WriteLine("玩家二本回合结束后的血量" + P2HP);
            //Console.WriteLine("玩家二本回合结束后的能量" + P2MP);
        }

        public static int Judge(ref int P1HP,ref int P1MP, ref int P2HP, ref int P2MP, Operation P1Operation, Operation P2Operation)
        {
            int P1HPf = 0;              //最终判定玩家1的生命值变化值
            int P1MPf = 0;              //最终判定玩家1的能量变化值
            int P2HPf = 0;              //最终判定玩家2的生命值变化值
            int P2MPf = 0;              //最终判定玩家2的能量变化值

            if (P1Operation.Num == 1)           //操作1情况
                if (P2Operation.Type != 2)  
                    P1Operation.MP += 3;
            if (P2Operation.Num == 1)
                if (P1Operation.Type != 2)
                    P2Operation.MP += 3;

            if (P1Operation.Num == 2)           //操作2情况
            {
                if(P2Operation.Type==2)
                {
                    P1Operation.MP += P2Operation.DPS;
                    P2Operation.DPS -= 2;
                }
            }
            if (P2Operation.Num == 2)
            {
                if (P1Operation.Type == 2)
                {
                    P2Operation.MP += P1Operation.DPS;
                    P1Operation.DPS -= 2;
                }
            }

            if (P1Operation.Num == 3)           //操作3情况
                P1Operation.MP += P2Operation.DPS * 2;
            if (P2Operation.Num == 3)
                P2Operation.MP += P1Operation.DPS * 2;

            if (P1Operation.Num == 4)           //操作4情况
                if (P2Operation.Type != 2)
                    P1Operation.MP += 10;
            if (P2Operation.Num == 4)
                if (P1Operation.Type != 2)
                    P2Operation.MP += 10;

            if (P1Operation.Num == 8)           //操作8情况
                P2Operation.AC = 0;
            if (P2Operation.Num == 8)
                P1Operation.AC = 0;

            if (P1Operation.Num == 9)           //操作9情况
                P2Operation.AC = 0;
            if (P2Operation.Num == 9)
                P1Operation.AC = 0;

            if(P1Operation.Num == 14)           //操作14情况
            {
                P2HP -= 99999;
                return 0;
            }
            if (P2Operation.Num == 14)
            {
                P1HP -= 99999;
                return 0;
            }

            if (P1Operation.Num == 17)           //操作17情况
                if (P2Operation.Type==2)
                    P1Operation.MP += 3;
            if (P2Operation.Num == 17)
                if (P1Operation.Type == 2)
                    P2Operation.MP += 3;

            if (P1Operation.Num == 18)           //操作18情况
                if (P2Operation.Type != 2)
                    P1Operation.HP += 2;
            if (P2Operation.Num == 18)
                if (P1Operation.Type != 2)
                    P2Operation.HP += 2;

            if (P1Operation.Num == 20)           //操作20情况
                if(P2Operation.Type!=2)
                    P1Operation.HP += 5;
            if (P2Operation.Num == 20)
                if(P1Operation.Type!=2)
                    P2Operation.HP += 5;

            if (P1Operation.Num == 22)           //操作22情况
                if (P2Operation.Type != 2)
                    P1Operation.HP += 10;
            if (P2Operation.Num == 22)
                if (P1Operation.Type != 2)
                    P2Operation.HP += 10;

            if (P1Operation.Num == 23)           //操作23情况
            {
                P1Operation.HP += P2Operation.DPS;
                P2Operation.DPS = 0;
            }
            if (P2Operation.Num == 23)
            {
                P2Operation.HP += P1Operation.DPS;
                P1Operation.DPS = 0;
            }


            P1Operation.DPS = P1Operation.DPS - P2Operation.AC; //结算伤害
            P2Operation.DPS = P2Operation.DPS - P1Operation.AC;
            if (P1Operation.DPS < 0)
                P1Operation.DPS = 0;
            if (P2Operation.DPS < 0)
                P2Operation.DPS = 0;

            if (P1Operation.Num == 11)          //操作11情况
                P1Operation.HP += P1Operation.DPS;
            if (P2Operation.Num == 11)
                P2Operation.HP += P2Operation.DPS;

            if (P1Operation.Num == 12)          //操作12情况
                P1Operation.MP += P1Operation.DPS;
            if (P2Operation.Num == 12)
                P2Operation.MP += P2Operation.DPS;

            if (P1Operation.Num == 13)          //操作13情况
            {
                P1Operation.HP += P1Operation.DPS;
                P1Operation.MP += P1Operation.DPS;
            }
            if (P2Operation.Num == 13)
            {
                P2Operation.HP += P2Operation.DPS;
                P2Operation.MP += P2Operation.DPS;
            }


            P1HPf = P1Operation.HP - P2Operation.DPS;
            P1MPf = P1Operation.MP;
            P2HPf = P2Operation.HP - P1Operation.DPS;
            P2MPf = P2Operation.MP;
            P1HP += P1HPf;
            P1MP += P1MPf;
            P2HP += P2HPf;
            P2MP += P2MPf;
            return 0;
        }

        public static void Initialise()//为每个操作赋属性
        {
            operations = new Operation[OpNum];
            for (int i = 0; i < OpNum; i++)
            {
                operations[i].Num = i;
            }
            for (int i = 0; i <= 4; i++)
            {
                operations[i].Type = 1;
            }
            for (int i = 5; i <= 14; i++)
            {
                operations[i].Type = 2;
            }
            for (int i = 15; i < 17; i++)
            {
                operations[i].Type = 3;
            }
            for (int i = 18; i < 23; i++)
            {
                operations[i].Type = 4;
            }
            operations[0].MP = 2;
            operations[2].MP = -1;
            operations[3].MP = -4;
            operations[4].MP = -5;
            operations[6].MP = -1;
            operations[6].DPS = 1;
            operations[7].MP = -2;
            operations[7].DPS = 3;
            operations[8].MP = -2;
            operations[8].DPS = 2;
            operations[9].MP = -5;
            operations[9].DPS = 4;
            operations[10].MP = -5;
            operations[10].DPS = 7;
            operations[11].MP = -5;
            operations[11].DPS = 5;
            operations[12].MP = -5;
            operations[12].DPS = 5;
            operations[13].MP = -7;
            operations[13].DPS = 5;
            operations[15].AC = 3;
            operations[16].MP = -2;
            operations[16].AC = 5;
            operations[17].MP = -3;
            operations[17].AC = 9999;
            operations[19].MP = -2;
            operations[19].HP = 3;
            operations[20].MP = -2;
            operations[21].MP = -5;
            operations[21].HP = 6;
            operations[22].MP = -5;
            operations[23].MP = -5;
        }
    }
}
