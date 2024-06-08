using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace InterfazTicketsApp
{
    public partial class CommentsPage : ContentPage
    {
        public ObservableCollection<Comment> Comments { get; set; }
        public string NewComment { get; set; }
        public ICommand SubmitCommentCommand { get; set; }

        public CommentsPage()
        {
            InitializeComponent();
            BindingContext = this;
            Comments = new ObservableCollection<Comment>
            {
                new Comment { UserName = "Juan P�rez", CommentText = "�Excelente evento!" },
                new Comment { UserName = "Mar�a G�mez", CommentText = "Me encant� la organizaci�n." }
            };

            SubmitCommentCommand = new Command(OnSubmitComment);
        }

        private void OnSubmitComment()
        {
            if (!string.IsNullOrWhiteSpace(NewComment))
            {
                Comments.Add(new Comment { UserName = "Usuario Actual", CommentText = NewComment });
                NewComment = string.Empty;
                OnPropertyChanged(nameof(NewComment));
            }
        }
    }

    public class Comment
    {
        public string UserName { get; set; }
        public string CommentText { get; set; }
    }
}
