﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BankClient.BLL.User
{
    namespace Account
    {
        public class ServiceUser
        {
            public bool RegisterUser(User user, out string message)
            {
                try
                {
                    using (var db = new LiteDatabase(@"kkb.db"))
                    {
                        var users = db.GetCollection<User>("Users");
                        users.Insert(user);
                    }
                    message = "Регистрация прошла успешно";
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
            public User LogOn(string login, string password, out string message)
            {
                User user = null;
                try
                {
                    using (var db = new LiteDatabase(@"kkb.db"))
                    {
                        #region проверка логина и пароля
                        var users = db.GetCollection<User>("Users");
                        IEnumerable<User> results = users.Find(x => x.Login.Equals(login) && x.Password.Equals(password));
                        //есть ли хоть одна запись в массиве
                        if (results.Any())
                        {
                            message = "";
                            //первую или null вернет из results
                            return results.FirstOrDefault();
                        }
                        else
                        {
                            message = "Неправильно ввели логин или пароль";
                            return user;
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return user;
                }
            }
        }
    }
}
