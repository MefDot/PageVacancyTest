using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageVacancyTest
{
    public class Tests
    {

        private readonly string PageUrl = "https://careers.veeam.ru/vacancies";
        private IWebDriver driver;

        // SelectBox со списком отделов
        private By _selectAllDepartament = By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div");
        private By _itemDevProduct = By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/div/a[4]");
        // SelectBox со списком языков
        private By _selectLanguage = By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div");
        private By _checkboxEnglish = By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div/div[2]");

        private By _vacancyCard = By.ClassName("card");

        // Параметр количества вакансий 
        private int _vacancyCount = 6; 

        


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(PageUrl);
        }

        [Test]
        public void Test1()
        {
            var departament = driver.FindElement(_selectAllDepartament);
            departament.Click();

            var devProduct = driver.FindElement(_itemDevProduct);
            devProduct.Click();

            var selectLanguage = driver.FindElement(_selectLanguage);
            selectLanguage.Click();

            var selectEnglish = driver.FindElement(_checkboxEnglish);
            selectEnglish.Click();

            var VacancyCard = driver.FindElements(_vacancyCard);

            Assert.AreEqual(_vacancyCount, VacancyCard.Count - 1);


        }
    }
}