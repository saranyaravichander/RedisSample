using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackExchange.Redis;
using System.Configuration;

namespace RedisSample
{
    public partial class _Default : Page
    {
        static Dictionary<string, string> database = new Dictionary<string, string>
        {
            { "key1","answer1" },
            { "key2","answer2" },
            { "key3","answer3" },
            { "key4","answer4" },
        };

        IDatabase cache = lazyConnection.Value.GetDatabase();

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var cachedValue = cache.StringGet(TextBox1.Text);

            if (database.ContainsKey(TextBox1.Text))
            {

               if (cachedValue == RedisValue.EmptyString || cachedValue == RedisValue.Null)
                {
                    Label1.Text = "Result : " + database[TextBox1.Text] + " || Got from the database";
                    cache.StringSet(TextBox1.Text, database[TextBox1.Text]);
                }
                else
                {
                    Label1.Text = "Result : " + cache.StringGet(TextBox1.Text).ToString() + " || Got from the cache";
                }
            }
            else
            {
                Label1.Text = "Enter only keys : key1, key2, key3, key4";
            }
        }
    }
}