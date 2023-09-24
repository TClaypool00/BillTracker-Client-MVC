using BillTrackerClient.App.CoreModels.PartialCoreModels;
using BillTrackerClient.App.Models.PostModels;
using System;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreCompany : PartialCoreCompany
    {
        private readonly PostCompanyViewModel _commentViewModel;
        private int _userId;

        public CoreCompany()
        {
            
        }

        public CoreCompany(PostCompanyViewModel commentViewModel, int userId)
        {
            _commentViewModel = commentViewModel ?? throw new ArgumentNullException(nameof(commentViewModel));

            if (userId <= 0)
            {
                throw new ApplicationException("User Id cannot be less than 0");
            }
            else
            {
                _userId = userId;
            }

            _commentViewModel.CompanyName = _commentViewModel.CompanyName.Trim();

            if (_commentViewModel.CompanyName.Contains(' '))
            {
                var words = _commentViewModel.CompanyName.Split(' ');
                string word;

                for (int i = 0; i < words.Length; i++)
                {
                    word = words[i];
                    word = UpperCaseFirstWord(word);
                    CompanyName += $"{word} ";
                }

                CompanyName = CompanyName.Trim();
            }
            else
            {
                CompanyName = UpperCaseFirstWord(_commentViewModel.CompanyName);
            }
        }

        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
        public CoreUser User { get; set; }

        #region private methods
        private static string UpperCaseFirstWord(string word)
        {
            return $"{word[0].ToString().ToUpper()}{word[1..].ToLower()}";
        }
        #endregion
    }
}
