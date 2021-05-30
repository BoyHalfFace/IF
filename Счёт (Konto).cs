using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Konto
    {
                                //Обьявления Конструкторов
        private string owner;   //Переменная

        public string Owner     //Конструктор
        {                       //(ЗащитаОтНаписания)
            get { return owner; }// Возвращаемое значение меняется в зависимости от имени
            // set { owner = value; } Разрешает измениния в защещенном файле
        }
                                //конец обьявления
        private double balance;

        public double Balance
        {
            get { return balance; }
            // set { saldo = value; }
        }

        private int pCode;

        private bool online;

        public bool Online
        {
            get { return online; }
            // set { eingeloggt = value; }
        }
                                                //Обьявление переменных в классе
        public Konto(string owner, int pCode)   //Список используемых переменных
        {
            this.owner = owner;                 //Если они не имеют значения - они пишутся вот так
                                                //this.+name = name; !!И они обьявляются сверху!!
            this.pCode = pCode;
            balance = 0;                        //Если же у них есть или нужно самостоятельно
                                                //обьявить какое-то значение - то они пишутся просто
                                                // имя = значение; !!И не обьявляются сверху!!
            online = false;
        }

        public bool Offline(int pCode)          //Так выглядит Метод
        {
            if (this.pCode == pCode)
            {
                return online = true;
            }
            else
            {
                return online = false;
            }
        }

        public bool Offline()
        {
            online = false;
            return true;
        }

        public bool Deposit(double amount)          //Добавляет деньги на счет
        {                                           //Если пользователь онлайн или если счёт 
            if (amount < 0 || !online)              //не меньше нуля
            {
                return false;                       //Если счёт меньше нуля или пользователь оффлайн
                                                    //(amount < 0 || !online) 
            }                                       //Возвращается значение false
            else
            {                                       //В ином случае к счёту прибавляется деньги(balance += amount)
                balance += amount;                  //И возвращется значение true
                return true;
            }

        }

        public bool WithdrawMoney(double amount)    //Снятие денег
        {
            if (amount < 0 || !online || amount > balance)  //Если кол-во желаемых денег для снятие(amount) 
            {                                               //меньше нуля(<0) или если они больше всех
                return false;                               //денег на счету(amount > balance)
                                                            //и пользователь не онлайн (!online)
            }                                               //Возвращается значение false
            else
            {                                               //В ином случае от Общей суммы(balance)
                balance -= amount;                          //Отнимается кол-во снятие желаемых денег
                return true;                                //И возвращается значение true
            }

        }

        public bool PinCodeChange(int pCode)                
        {
            if (online)
            {
                this.pCode = pCode;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()           //Метод для отображение полученных результатов
        {
            string s = $"{owner}: {balance} Euro";  //!Важно! В переменную s сохраняется любые значения
            if (online)                             //которые позже будут показаны
            {                                       
                s += $" (online)";                  //Если пользователь онлайн - то помимо этого будет 
            }                                       //Выведенно online (s+=$"(online)")
            else
            {                                       //В ином же случае будет выведено,что пользователь
                s += $" (offline)";                 // Оффлайн
            }
            return s;                               //Возвращается то,что будет выведено.
        }





    }
}
