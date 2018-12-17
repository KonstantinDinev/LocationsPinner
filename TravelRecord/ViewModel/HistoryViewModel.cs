using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelRecord.Model;
using Xamarin.Forms;

namespace TravelRecord
{
    public class HistoryViewModel
    {
        public ObservableCollection<Post> Posts { get; set; }

        public ICommand DeletePostCommand { get; private set; }

        public HistoryViewModel()
        {
            Posts = new ObservableCollection<Post>();

            DeletePostCommand = new Command<Post>(async c => await DeletePost(c));
        }

        public async Task<bool> UpdatePosts()
        {
            try
            {
                var posts = await Post.Read();
                if (posts != null)
                {
                    Posts.Clear();
                    foreach (var post in posts)
                        Posts.Add(post);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task DeletePost(Post postToDelete)
        {
            //not binded ..
            await Post.Delete(postToDelete);

            //Post post = (Post)App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id && p.Id == postToDelete.Id);
            //await Post.Delete(post);
            //UpdatePosts();
        }

    }
}
