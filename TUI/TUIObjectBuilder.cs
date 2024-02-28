using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;
using TUI.TUIParts;

namespace TUI
{
    public class TUIObjectBuilder:ITUIObjectBuilder
    {
        private TUIObject _Product = new();

        public ObjectBuilderDefaults Defaults { get; set; }
        public Dictionary<string, TUIObject> Output { get; set; }

        public TUIObjectBuilder()
        {
            Defaults = new ObjectBuilderDefaults();
        }

        public TUIObjectBuilder(ObjectBuilderDefaults defaults)
        {
            Defaults = defaults;
        }

        public TUIObjectBuilder(Dictionary<string, TUIObject> output, ObjectBuilderDefaults defaults)
        {
            Defaults = defaults;
            Output = output;
        }

        public TUIObjectBuilder(Dictionary<string, TUIObject> output)
        {
            Output = output;

        }

        public TUIObject Build(Anchor anchor)
        {
            _Product.Anchor = anchor;
           TUIObject product = _Product;
            Reset();
            return product;
        }

        public TUIObject Build()
        {
            _Product.Anchor = Defaults.Anchor;
            TUIObject product = _Product;

            Reset();
            return product;
        }

        public void Build(string name,Anchor? anchor=null)
        {

            anchor ??= new();

            _Product.Anchor =(Anchor) anchor;
            Output.Add(name, _Product);
        }

        public void Reset()
        {
            _Product=new();
        }

        public int CountOfParts<T>() where T : ITUIObjectPart
        {
            return _Product.Parts?.Where(p=> p is T).Count()??0;    
        }
        public int LenghthOfLongestLabel()
        {
            List<TUILabelPart> labels = new();

            _Product.Parts.Where(p => p is TUILabelPart).ToList().ForEach(l=>labels.Add((TUILabelPart)l.Value));

            return labels.OrderByDescending(l => l.Content.Length).First().Content.Length;
        }

        public TUIObjectBuilder AddTextBox(string name, int width,int? height=null,Anchor? anchor = null,string? text=null,bool? isEnabled=null, ConsoleColor? interactionForeGround = null, ConsoleColor? interactionBackGround = null, ConsoleColor? foreColor = null, ConsoleColor? backColor = null)
        {
            anchor = anchor ?? Defaults.Anchor;
            height = height ?? 1;
            foreColor = foreColor ?? Defaults.ButtonDefaults.ForeGround;
            backColor=backColor?? Defaults.ButtonDefaults.BackGround; 
            interactionForeGround=interactionForeGround ?? Defaults.ButtonDefaults.InteractionForeGround;
            interactionBackGround = interactionBackGround ?? Defaults.ButtonDefaults.InteractionBackground;
            isEnabled = isEnabled ?? true;

            TUITextBoxPart tb = new(name,anchor,width,(int)height,text!,(ConsoleColor)foreColor, (ConsoleColor)backColor, (ConsoleColor)interactionForeGround, (ConsoleColor)interactionBackGround,(bool)isEnabled,TUIObjectPartType.PROGRESS_BAR);
            _Product.AddPart(tb);
            
            return this;
        }
        public TUIObjectBuilder AddLabel(string name, string? content, Anchor? anchor=null, ConsoleColor? foreColor = null, ConsoleColor? backColor = null, bool? isEnabled=null)
        {
            anchor=anchor?? Defaults.Anchor;
            foreColor = foreColor ?? Defaults.ForeGround;
            backColor = backColor ?? Defaults.BackGround;
            isEnabled = isEnabled ?? true;

            TUILabelPart label = new(name,anchor,content,(ConsoleColor)foreColor, (ConsoleColor)backColor,(bool)isEnabled,TUIObjectPartType.LABEL);
            _Product.AddPart(label);
            return this;
        }
        /// <summary>
        /// Adds frame to object
        /// </summary>
        /// <param name="name">Name of the part</param>
        /// <param name="width">Width of the free space</param>
        /// <param name="height">Height of the free space</param>
        /// <param name="anchor">Anchor or object, currently top left corner</param>
        /// <param name="frameOptions">Options for frame walls</param>
        /// <param name="foreGround"></param>
        /// <param name="backGround"></param>
        public TUIObjectBuilder AddFrame(string name, int width, int height, Anchor? anchor = null, FrameOptions? frameOptions = null, ConsoleColor? foreColor = null, ConsoleColor? backColor = null,bool? isEnabled=null)
        {
                anchor =anchor?? Defaults.Anchor;
            foreColor = foreColor ?? Defaults.ForeGround;
            backColor = backColor ?? Defaults.BackGround;
            isEnabled = isEnabled ?? true;
                frameOptions =frameOptions?? Defaults.FrameOptions;

            width+= 2;
            height += 2;
            TUIFramePart frame = new(name,anchor,width,height,frameOptions,(ConsoleColor)foreColor, (ConsoleColor)backColor,(bool)isEnabled,TUIObjectPartType.FRAME);
            _Product.AddPart(frame);
            return this;
        }

        public TUIObjectBuilder AddButton(string name, string? content,Action action, Anchor? anchor = null, ConsoleColor? interactionForeGround = null, ConsoleColor? interactionBackGround = null, ConsoleColor? foreColor = null, ConsoleColor? backColor = null,bool? isEnabled=null)
        {
            if (_Product.IsInteractable)
                throw new Exception("There can be only one interactable part at same time in one object");

            anchor = anchor ?? Defaults.Anchor;
            foreColor = foreColor ?? Defaults.ButtonDefaults.ForeGround;
            backColor = backColor ?? Defaults.ButtonDefaults.BackGround;
            interactionForeGround = interactionForeGround ?? Defaults.ButtonDefaults.InteractionForeGround;
            interactionBackGround = interactionBackGround ?? Defaults.ButtonDefaults.InteractionBackground;
            isEnabled = isEnabled ?? true;


            TUIButtonPart button = new(name,anchor,content,(ConsoleColor)foreColor, (ConsoleColor)backColor, (ConsoleColor)interactionForeGround, (ConsoleColor)interactionBackGround,(bool) isEnabled,TUIObjectPartType.BUTTON);
            button.Action=action;
            _Product.AddPart(button);
            return this;

        }
        public TUIObjectBuilder AddProgressBar(string name,Anchor? anchor,int width,int height ,int value=0, int maximum=100, int minimum=0, ConsoleColor? foreColor = null, ConsoleColor? backColor = null, bool? isEnabled = null)
        {
            anchor ??= Defaults.Anchor;
            foreColor ??= ConsoleColor.DarkMagenta;
            backColor ??= ConsoleColor.Gray;
            isEnabled ??= true;

            TUIProgressBarPart pb =new (name,anchor,width,height,value,maximum,minimum, (ConsoleColor)foreColor, (ConsoleColor)backColor,(bool)isEnabled,TUIObjectPartType.PROGRESS_BAR);
            

            _Product.AddPart(pb);

            return this;
        }
        public TUIObjectBuilder AddRadioButton(string name,int radioFamily,string? content,bool? isTicked=null, Anchor? anchor = null, ConsoleColor? interactionForeGround = null, ConsoleColor? interactionBackGround = null, ConsoleColor? foreColor = null, ConsoleColor? backColor = null, bool? isEnabled = null)
		{
			anchor ??= Defaults.Anchor;
            content ??= string.Empty;

            foreColor ??= Defaults.ButtonDefaults.ForeGround;
            backColor??= Defaults.ButtonDefaults.BackGround;
            
            interactionForeGround??=Defaults.ButtonDefaults.InteractionForeGround;
            interactionBackGround ??= Defaults.ButtonDefaults.InteractionBackground;

            isTicked??=false;
            isEnabled ??= true;


            TUIRadioButtonPart rb = new(name,radioFamily,content,(bool)isTicked,anchor,(ConsoleColor)foreColor, (ConsoleColor)backColor,(ConsoleColor)interactionForeGround,(ConsoleColor)interactionBackGround,(bool)isEnabled,TUIObjectPartType.RADIO_BUTTON);
            _Product.AddPart(rb);
            return this;
        }
    }
}
