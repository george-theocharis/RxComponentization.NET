using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SampleApp.Model;

namespace SampleApp.Components.ResultsComponent
{
    internal class PostAdapter : RecyclerView.Adapter
    {
        private List<Post> _posts;
        public PostAdapter()
        {
            _posts = new List<Post>();
        }

        public override int ItemCount => _posts.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as PostsViewHolder;

            vh.Bind(_posts[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.post, parent, false);

            var item = new PostsViewHolder(view);

            return item;
        }

        internal void Update(IEnumerable<Post> results)
        {
            _posts.Clear();
            _posts.AddRange(results);
            NotifyDataSetChanged();
        }
    }

    internal class PostsViewHolder : RecyclerView.ViewHolder
    {
        public PostsViewHolder(View itemView) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.tv_value);
        }

        public TextView Title { get; }

        internal void Bind(Post post)
        {
            Title.Text = post.Title;
        }
    }
}
