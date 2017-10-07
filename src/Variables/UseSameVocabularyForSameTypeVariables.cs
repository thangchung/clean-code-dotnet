namespace CleanCodeDotNet.Variables
{
    public class UseSameVocabularyForSameTypeVariables
    {
        public UseSameVocabularyForSameTypeVariables()
        {
            // Bad
            GetUserInfo();
            GetUserData();
            GetUserRecord();
            GetUserProfile();

            // Good
            GetUser();
        }

        private object GetUserInfo() { return "dummy"; }
        private object GetUserData() { return "dummy"; }
        private object GetUserRecord() { return "dummy"; }
        private object GetUserProfile() { return "dummy"; }
        private object GetUser() { return "dummy"; }
    }
}
