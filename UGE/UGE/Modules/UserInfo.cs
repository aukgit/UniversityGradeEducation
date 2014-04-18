using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UGE.Models.DbContext;
using AspUser = Microsoft.AspNet.Identity.IUser;

namespace Modules {
    public class UserInfo {
        UGEContext _Db;
        MembershipUser _AspUser;
        User _DbUser;

        public UserInfo() {
            _Db = new UGEContext();
        }

        public bool IsUserExist(string log) {
            if (_Db.Users.Any(n => n.UserName == log)) {
                return true;
            }
            return false;
        }

        public bool IsUserExist(int id) {
            if (_Db.Users.Any(n => n.UserID == id)) {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Returns custom database user.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public User GetUser(int userid) {
            if (_DbUser != null && _DbUser.UserID == userid) {
                return _DbUser;
            }
            return _DbUser = _Db.Users.Find(userid);
        }

        /// <summary>
        ///     Get current logged user record from db.
        /// </summary>
        /// <returns></returns>
        public User GetUser() {
            if (IsAuthenticated()) {
                return GetUser(GetAspUserCurrentUser().Identity.Name);
            }
            return null;
        }

        /// <summary>
        ///     Returns the custom database user.
        /// </summary>
        /// <param name="log">By log name.</param>
        /// <returns></returns>
        public User GetUser(string log) {
            if (_DbUser != null && _DbUser.UserName == log) {
                return _DbUser;
            }
            _DbUser = _Db.Users.FirstOrDefault(c => c.UserName == log);
            return _DbUser;
        }
       

        public bool IsAuthenticated() {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

       
        public bool IsCurrentUserSessionExist() {
            if (IsAuthenticated() && HttpContext.Current.Session != null && HttpContext.Current.Session[SessionNames.User] != null) {
                var user = (User)HttpContext.Current.Session[SessionNames.User];
                if (user == null) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        /// <summary>
        ///     If db user exist on the session return from session
        ///     or else get it and then save it to the session.
        /// </summary>
        /// <returns></returns>
        public User GetUserSession() {
            User user;
            if (IsCurrentUserSessionExist()) {
                user = (User) HttpContext.Current.Session[SessionNames.User];
                if (user != null) {
                    return user;
                }
            }
            user = GetUser(GetAspUserCurrentUser()
                               .Identity.Name);
            if (user == null) {
                return null;
            }
            HttpContext.Current.Session[SessionNames.User] = user;
            return user;
        }

        /// <summary>
        ///     Get user id from session or asp.net->db->session(keep);
        /// </summary>
        /// <returns>Return -1 when not found.</returns>
        public int GetUserID() {
            var useridCookie = HttpContext.Current.Request.Cookies[CookiesNames.UserID];

            if (useridCookie != null) {
                int userid;
                if (int.TryParse(useridCookie.Value, out userid)) {
                    return userid;
                }
            }
       
            return -1;
        }


        public string AuthenticatedUserName() {
            if (IsAuthenticated()) {
                return GetAspUserCurrentUser()
                    .Identity.Name;
            }
            return "";
        }

        public bool IsAuthenticated(string log) {
            if (_AspUser != null && log == _AspUser.UserName) {
                return _AspUser.IsOnline;
            }
            _AspUser = Membership.GetUser(log);
            return _AspUser != null && _AspUser.IsOnline;
        }

        public MembershipUser GetAspUser(string log) {
            if (_AspUser != null && log == _AspUser.UserName) {
                return _AspUser;
            }
            _AspUser = Membership.GetUser(log);
            return _AspUser;
        }

        public IPrincipal GetAspUserCurrentUser() {
            if (HttpContext.Current.User.Identity.IsAuthenticated) {
                return HttpContext.Current.User;
            }

            return null;
        }
    }
}