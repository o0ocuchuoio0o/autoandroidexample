using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using Appium.Net.Integration.Tests.helpers;
using OpenQA.Selenium.Appium.Enums;

namespace demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private AndroidDriver<IWebElement> _driver;
        private const string DemoAppPackage = "com.google.android.youtube";

        private void button1_Click(object sender, EventArgs e)
        {

            //var capabilities = Caps.GetAndroidCaps(Apps.Get("androidApiDemos"));

            //var serverUri = Env.ServerIsRemote() ? AppiumServers.RemoteServerUri : AppiumServers.LocalServiceUri;
            //_driver = new AndroidDriver<IWebElement>(serverUri, capabilities, Env.InitTimeoutSec);
            //_driver.Manage().Timeouts().ImplicitWait = Env.ImplicitTimeoutSec;
            //_driver.CloseApp();


            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.AndroidUIAutomator2);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.AddAdditionalCapability("appPackage", "com.google.android.youtube");           
            _driver = new AndroidDriver<IWebElement>(new Uri("https://127.0.0.1:4723/wd/hub"), capabilities, Env.InitTimeoutSec);
            _driver.Manage().Timeouts().ImplicitWait = Env.ImplicitTimeoutSec;
            _driver.CloseApp();

        }
    }
}
