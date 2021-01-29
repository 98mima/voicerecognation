using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace Voice_Recognition
{
    public partial class Form1 : Form
    {

        SpeechRecognitionEngine _RecognitionEngine = new SpeechRecognitionEngine();
        SpeechRecognitionEngine _Start_Listening = new SpeechRecognitionEngine();
        SpeechSynthesizer _Speech = new SpeechSynthesizer();

        int RecognitionTimeout = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(
                new string[] { "what is your name", "what time is it", "how are you",
                "search","open cs", "open sip", "location", "what is the weather",  "what is your favourite song"}
                );
            GrammarBuilder grammerBuilder = new GrammarBuilder();
            grammerBuilder.Append(commands);
            Grammar grammer = new Grammar(grammerBuilder);


            _RecognitionEngine.SetInputToDefaultAudioDevice(); //mora da postoji audio device na uredjaju na kome se izvrsava aplikacija.
            _RecognitionEngine.LoadGrammarAsync(grammer);
            _RecognitionEngine.SpeechRecognized += SpeechRecognized;
            _RecognitionEngine.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(RecognizerSpeachRecognized);

        }

        private void RecognizerSpeachRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecognitionTimeout = 0;
        }

        private void Enable_Click(object sender, EventArgs e)
        {
            _RecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            Disable.Enabled = true;
            Enable.Enabled = false;
        }

        void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch(e.Result.Text)
            {
                case "what is your name":
                    _Speech.SpeakAsync("My name is Miki");
                    break;
                case "how are you":
                    _Speech.SpeakAsync("I'm fine, how are you?");
                    break;
                case "what time is it":
                    string date = DateTime.Now.ToString("h mm tt");
                    _Speech.SpeakAsync(date);
                    textConsole.Text += date + Environment.NewLine;
                    break;
                case "search":
                    _Speech.SpeakAsync("What do you want to searh for?");
                    textConsole.Text = "Searching Google" + Environment.NewLine;
                    string url = "https://google.com/search?q=";
                    Process.Start(url);
                    break;
                case "location":
                    _Speech.SpeakAsync("Here is your location");
                    textConsole.Text += "Searching your location" + Environment.NewLine;
                    string urlLocation = "https://www.google.com/maps/place/%D0%A2%D1%80%D0%B3+%D0%9A%D1%80%D0%B0%D1%99%D0%B0+%D0%9C%D0%B8%D0%BB%D0%B0%D0%BD%D0%B0/@43.3228953,21.8965095,15.79z/data=!4m5!3m4!1s0x4755b0b43bbdeb79:0xfad80518e091d85c!8m2!3d43.3214351!4d21.895768";
                    Process.Start(urlLocation);
                    break;
                case "what is the weather":
                    _Speech.SpeakAsync("Here is your weather");
                    textConsole.Text += "Searching weather" + Environment.NewLine;
                    string weather = "https://www.accuweather.com/sr/rs/nis/299758/weather-forecast/299758";
                    Process.Start(weather);
                    break;
                case "open cs":
                    _Speech.SpeakAsync("Opening CS");
                    textConsole.Text += "Open cs" + Environment.NewLine;
                    string facebook = "https://cs.elfak.ni.ac.rs/nastava/";
                    Process.Start(facebook);
                    break;
                case "open sip":
                    _Speech.SpeakAsync("Opening SIP");
                    textConsole.Text += "Open SIP" + Environment.NewLine;
                    string youtube = "https://sip.elfak.ni.ac.rs/";
                    Process.Start(youtube);
                    break;
                case "what is your favourite song":
                    _Speech.SpeakAsync("Listen");
                    textConsole.Text += "Open youtube" + Environment.NewLine;
                    string song = "https://www.youtube.com/watch?v=lDK9QqIzhwk";
                    Process.Start(song);
                    break;
                default:
                    _Speech.SpeakAsync("I did not recognize that");
                    break;

            }
        }

        private void Disable_Click(object sender, EventArgs e)
        {
            _RecognitionEngine.RecognizeAsyncStop();
            textConsole.Clear();
            Enable.Enabled = true;
            Disable.Enabled = false;
        }

        private void timerSpeech_Tick(object sender, EventArgs e)
        {
            if (RecognitionTimeout == 10) _RecognitionEngine.RecognizeAsyncCancel();
            else if (RecognitionTimeout == 11)
            {
                timerSpeech.Stop();
                _Start_Listening.RecognizeAsync(RecognizeMode.Multiple);
                textConsole.Clear();
                RecognitionTimeout = 0;
            }
        }

        private void textConsole_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
