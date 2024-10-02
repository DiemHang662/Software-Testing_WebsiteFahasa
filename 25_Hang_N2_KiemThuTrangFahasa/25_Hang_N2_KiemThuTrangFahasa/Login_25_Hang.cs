using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Text;

namespace _25_Hang_N2_KiemThuTrangFahasa
{
    [TestClass]
    public class Login_25_Hang
    {
        private IWebDriver driver_25_Hang;
        public void SetUp_25_Hang() // Phương thức này để truy cập vào trang web
        {
            driver_25_Hang = new ChromeDriver();  // Khởi tạo driver bằng trình duyệt Chrome
            driver_25_Hang.Navigate().GoToUrl("https://www.fahasa.com/");// Đưa url vào để mở trang web
        }

        [TestMethod] // Thực hiện kiểm thử test case
        public void TC1_LoginSuccessWithEmail_25_Hang() // TC1: Đăng nhập thành công với email
        {
            SetUp_25_Hang(); // Phương thức này để truy cập vào trang web
            Thread.Sleep(2000); // Chờ trang web load 2 giây

            // Lấy CssSelector của nút đăng nhập và click vào để hiện trang đăng nhập
            driver_25_Hang.FindElement(By.CssSelector("#fhs_top_account_hover > a > div")).Click();

            Thread.Sleep(2000); // Chờ trang web load 2 giây

            // Lấy Id của ô username và nhập username đó vào
            driver_25_Hang.FindElement(By.Id("login_username")).SendKeys("2151050116hang@ou.edu.vn");

            // Lấy Id của ô password và nhập password đó vào
            driver_25_Hang.FindElement(By.Id("login_password")).SendKeys("25_Hang");

            Thread.Sleep(3000); // Chờ trang web load 3 giây

            IWebElement btnLogin_25_Hang = driver_25_Hang.FindElement(By.CssSelector("#wrapper > div.page > div.main-container.col1-layout.no-margin-top > div > div.col-main > div > div > div.fhs_login_form > div > div > div.popup-login-content > form > div:nth-child(4) > div > button.fhs-btn-login"));
            
            btnLogin_25_Hang.Click(); // Click nút đăng nhập
        }

        [TestMethod] // Thực hiện kiểm thử test case
        public void TC2_LoginSuccessWithTel_25_Hang() // TC2: Đăng nhập thành công với số điện thoại
        {
            SetUp_25_Hang();// Phương thức này để truy cập vào trang web
            Thread.Sleep(2000); // Chờ trang web load 2 giây

            // Lấy CssSelector của nút đăng nhập và click vào để hiện trang đăng nhập
            driver_25_Hang.FindElement(By.CssSelector("#fhs_top_account_hover > a > div")).Click();

            Thread.Sleep(2000); // Chờ trang web load 2 giây

            // Lấy Id của ô username và nhập username đó vào
            driver_25_Hang.FindElement(By.Id("login_username")).SendKeys("0345554484");

            // Lấy Id của ô password và nhập password đó vào
            driver_25_Hang.FindElement(By.Id("login_password")).SendKeys("25_Hang");

            Thread.Sleep(3000); // Chờ trang web load 3 giây

            IWebElement btnLogin_25_Hang = driver_25_Hang.FindElement(By.CssSelector("#wrapper > div.page > div.main-container.col1-layout.no-margin-top > div > div.col-main > div > div > div.fhs_login_form > div > div > div.popup-login-content > form > div:nth-child(4) > div > button.fhs-btn-login"));
            
            btnLogin_25_Hang.Click(); // CLick nút đăng nhập
        }

        [TestMethod]  // Thực hiện kiểm thử test case
        public void TC3_LoginWithWrongEmail_25_Hang() // TC3: Đăng nhập không thành công với email sai
        {
            SetUp_25_Hang();// Phương thức này để truy cập vào trang web

            // Lấy CssSelector của nút đăng nhập và click vào để hiện trang đăng nhập            
            driver_25_Hang.FindElement(By.CssSelector("#fhs_top_account_hover > a > div")).Click();

            // Lấy Id của ô username và nhập username đó vào
            driver_25_Hang.FindElement(By.Id("login_username")).SendKeys("2151234@ou.edu.vn");

            // Lấy Id của ô password và nhập password đó vào
            driver_25_Hang.FindElement(By.Id("login_password")).SendKeys("25_Hang"); // Lấy Id của ô password

            // Lấy Css Selector của nút đăng nhập trang web và click vào để đăng nhập
            IWebElement btnLogin_25_Hang = driver_25_Hang.FindElement(By.CssSelector("#wrapper > div.page > div.main-container.col1-layout.no-margin-top > div > div.col-main > div > div > div.fhs_login_form > div > div > div.popup-login-content > form > div:nth-child(4) > div > button.fhs-btn-login"));          
            btnLogin_25_Hang.Click(); // Click vào nút đăng nhập

            // Nếu đăng nhập sai thì trong Test Explorer sẽ xuất ra thông báo và lỗi
            Console.WriteLine("Đăng nhập không thành công. Lỗi: nhập sai email");
            Thread.Sleep(7000); // Chờ trang web load 7 giây       
            // Đóng trình duyệt sau khi hoàn thành công việc
            driver_25_Hang.Quit();
        }


        [TestMethod]  // Thực hiện kiểm thử test case
        public void TC4_LoginWithWrongPass_25_Hang() // TC4: Đăng nhập không thành công với mật khẩu sai
        {
            SetUp_25_Hang();// Phương thức này để truy cập vào trang web

            // Lấy CssSelector của nút đăng nhập và click vào để hiện trang đăng nhập
            driver_25_Hang.FindElement(By.CssSelector("#fhs_top_account_hover > a > div")).Click();

            // Lấy Id của ô username và nhập username đó vào
            driver_25_Hang.FindElement(By.Id("login_username")).SendKeys("2151050116hang@ou.edu.vn");

            // Lấy Id của ô password và nhập password đó vào
            driver_25_Hang.FindElement(By.Id("login_password")).SendKeys("TestPass_25_Hang"); 

            // Lấy Css Selector của nút đăng nhập trang web và click vào để đăng nhập
            IWebElement btnLogin_25_Hang = driver_25_Hang.FindElement(By.CssSelector("#wrapper > div.page > div.main-container.col1-layout.no-margin-top > div > div.col-main > div > div > div.fhs_login_form > div > div > div.popup-login-content > form > div:nth-child(4) > div > button.fhs-btn-login"));
            btnLogin_25_Hang.Click(); // Click vào nút đăng nhập

            // Nếu đăng nhập sai thì trong Test Explorer sẽ xuất ra thông báo và lỗi
            Console.WriteLine("Đăng nhập không thành công. Lỗi: nhập sai mật khẩu");
            Thread.Sleep(7000); // Chờ trang web load 7 giây           
            driver_25_Hang.Quit(); // Đóng trình duyệt sau khi hoàn thành công việc/
        }

        [TestMethod]  // Thực hiện kiểm thử test case
        public void TC5_LoginFail_25_Hang() // TC5: Đăng nhập không thành công khi email và mật khẩu sai
        {
            SetUp_25_Hang();// Phương thức này để truy cập vào trang web

            // Lấy CssSelector của nút đăng nhập và click vào để hiện trang đăng nhập
            driver_25_Hang.FindElement(By.CssSelector("#fhs_top_account_hover > a > div")).Click();

            // Lấy Id của ô username và nhập username đó vào
            driver_25_Hang.FindElement(By.Id("login_username")).SendKeys("2151234@ou.edu.vn");

            // Lấy Id của ô password và nhập password đó vào
            driver_25_Hang.FindElement(By.Id("login_password")).SendKeys("Testloginfail_25_Hang"); // Lấy Id của ô password

            // Lấy Css Selector của nút đăng nhập trang web và click vào để đăng nhập
            IWebElement btnLogin_25_Hang = driver_25_Hang.FindElement(By.CssSelector("#wrapper > div.page > div.main-container.col1-layout.no-margin-top > div > div.col-main > div > div > div.fhs_login_form > div > div > div.popup-login-content > form > div:nth-child(4) > div > button.fhs-btn-login"));
            btnLogin_25_Hang.Click(); // Click nút đăng nhập

            // Nếu đăng nhập sai thì trong Test Explorer sẽ xuất ra thông báo và lỗi
            Console.WriteLine("Đăng nhập không thành công. Lỗi: sai email và mật khẩu");
            Thread.Sleep(7000); // Chờ trang web load 7 giây       

            driver_25_Hang.Quit();  // Đóng trình duyệt sau khi hoàn thành công việc
        }

    }
}
