using BillTrackerClient.App.CoreModels.PartialCoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models.PostModels;
using System;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreCompany : PartialCoreCompany
    {
        private readonly PostCompanyViewModel _commentViewModel;
        private int _userId;
        private readonly Company _company;

        public CoreCompany()
        {
            
        }

        public CoreCompany(Company company)
        {
            _company = company ?? throw new ArgumentNullException(nameof(company));

            if (_company.CompanyId > 0)
            {
                CompanyId = _company.CompanyId;
            }

            CompanyName = _company.CompanyName;
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

        public CoreCompany(int id, string name)
        {
            CompanyId = id;
            CompanyName = name;
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
