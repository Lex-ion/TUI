using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Structs;

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
            return _Product.Parts.Where(p=> p is T).Count();    
        }
        public int LenghthOfLongestLabel()
        {
            List<TUILabelPart> labels = new();

            _Product.Parts.Where(p => p is TUILabelPart).ToList().ForEach(l=>labels.Add((TUILabelPart)l.Value));

            return labels.OrderByDescending(l => l.Content.Length).First().Content.Length;
        }
        /// <summary>
        /// NotFinished
        /// </summary>
        /// <param name="name"></param>
        /// <param name="anchor"></param>
        /// <returns></returns>
        public TUIObjectBuilder AddTextBox(string name, int width,int? height=null,Anchor? anchor = null, ConsoleColor? interactionForeGround = null, ConsoleColor? interactionBackGround = null, ConsoleColor? foreGround = null, ConsoleColor? backGround = null)
        {
            if (anchor is null)
                anchor = Defaults.Anchor;
            if (foreGround is null)
                foreGround = Defaults.ButtonDefaults.ForeGround;
            if (backGround is null)
                backGround = Defaults.ButtonDefaults.Background;
            if (interactionForeGround is null)
                interactionForeGround = Defaults.ButtonDefaults.InteractionForeGround;
            if (interactionBackGround is null)
                interactionBackGround = Defaults.ButtonDefaults.InteractionBackground;

            if(height is null||height<1)
                height = 1;


            TUITextBoxPart tb = new();
            tb.Set(name, (Anchor)anchor, foreGround, backGround, interactionForeGround, interactionBackGround);
            tb.Width = width;
            tb.Height = (int)height;
            _Product.AddPart(tb);
            
            return this;
        }
        public TUIObjectBuilder AddLabel(string name, string? content, Anchor? anchor=null, ConsoleColor? foreGround = null, ConsoleColor? backGround = null)
        {
            if (anchor is null)
                anchor = Defaults.Anchor;
            if(foreGround is null)
                foreGround = Defaults.ForeGround;
            if (backGround is null)
                backGround = Defaults.BackGround;

            TUILabelPart label = (TUILabelPart) new TUILabelFactory().Create();
            label.Set(name, (Anchor)anchor, content, foreGround, backGround);
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
        public TUIObjectBuilder AddFrame(string name, int width, int height, Anchor? anchor = null, FrameOptions? frameOptions = null, ConsoleColor? foreGround = null, ConsoleColor? backGround = null)
        {
            if (anchor is null)
                anchor = Defaults.Anchor;
            if (foreGround is null)
                foreGround = Defaults.ForeGround;
            if (backGround is null)
                backGround = Defaults.BackGround;
            if (frameOptions is null)
                frameOptions = Defaults.FrameOptions;

             width+= 2;
            height += 2;
            TUIFramePart frame = new();
            frame.Set(name,height,width,(Anchor)anchor,frameOptions,foreGround,backGround);
            _Product.AddPart(frame);
            return this;
        }

        public TUIObjectBuilder AddButton(string name, string? content,Action action, Anchor? anchor = null, ConsoleColor? interactionForeGround = null, ConsoleColor? interactionBackGround = null, ConsoleColor? foreGround = null, ConsoleColor? backGround = null)
        {
            if (_Product.Parts.Any(p => p is ITUIInteractable))
                throw new Exception("There can be only one interactable part at same time in one objecet");

            if (anchor is null)
                anchor = Defaults.Anchor;
            if (foreGround is null)
                foreGround = Defaults.ButtonDefaults.ForeGround;
            if (backGround is null)
                backGround = Defaults.ButtonDefaults.Background;
            if(interactionForeGround is null)
                interactionForeGround = Defaults.ButtonDefaults.InteractionForeGround;
            if (interactionBackGround is null)
                interactionBackGround = Defaults.ButtonDefaults.InteractionBackground;

            TUIButtonPart button = new();
            button.Set(name, (Anchor)anchor, foreGround, backGround, interactionForeGround, interactionBackGround);
            button.Action=action;
            button.Content = content;
            _Product.AddPart(button);
            return this;

        }
        public TUIObjectBuilder AddProgressBar(string name,Anchor? anchor,int width,int height ,int value=0, int maximum=100, int minimum=0)
        {
            anchor ??= new();

            TUIProgressBarPart pb =new (name,anchor,width,height,value,maximum,minimum);
            

            _Product.AddPart(pb);

            return this;
        }
    }
}
