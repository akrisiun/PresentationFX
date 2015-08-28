using System;
using System.ComponentModel.Design;
using System.Runtime;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Interactivity;

// ### Interaction.Behaviors
//  xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
//  <i:Interaction.Behaviors>
//    <behaviours:BorderlessWindowBehavior />

namespace Interaction.Helper
{
    using MahApps.Metro.Controls;
    using Interaction = System.Windows.Interactivity.Interaction;
    using Interactivity = System.Windows.Interactivity;

    public class MetroBehaviors : FreezableCollection<Behavior>, IAttachedObject
    {
        #region Behaviors static 

        static MetroBehaviors() { } // Debugger entry point

        public static readonly DependencyProperty BorderlessWindowBehaviorProperty
            = DependencyProperty.Register("BorderlessWindowBehavior", typeof(bool),
                ownerType: typeof(Helper.MetroBehaviors), typeMetadata: new PropertyMetadata(null));

        public bool BorderlessWindowBehavior
        {
            get
            {
                var value = GetValue(BorderlessWindowBehaviorProperty);
                return (value is bool) ? (bool)value : false;
            }
            set { SetValue(BorderlessWindowBehaviorProperty, value); }
        }

        public static BehaviorCollection GetBehaviors(DependencyObject obj) { return Interaction.GetBehaviors(obj); }
        public static Interactivity.TriggerCollection GetTriggers(DependencyObject obj) { return Interaction.GetTriggers(obj); }

        #endregion

        public MetroBehaviors() : base() { }

        #region Virtual

        //public AttachableCollection<Behavior> Wrap { get; set; }
        //public IAttachedObject Obj() { return Wrap as IAttachedObject; }

        public virtual DependencyObject AssociatedObject { get { return null; } } // Obj().AssociatedObject; } }
        public virtual void Attach(DependencyObject dependencyObject)
        {
            // Obj().Attach(dependencyObject);
        }

        public virtual void Detach()
        {
            // Obj().Detach();
        }

        public static void SetBehavior(MetroWindow dependencyObject, Behavior behavior)
        {
            //var clone = (Behavior)behavior.Clone();
            //dependencyObject.SetValue(MetroWindow.Origin)

            //SetOriginalBehavior(DependencyObject obj, Behavior value)
            //obj.SetValue(OriginalBehaviorProperty, value);
            //itemBehaviors.Add(clone);
            //dependencyObject.OnAttached();
        }

        protected override Freezable CreateInstanceCore() { return null; }
        public virtual void Dispose() { }

        // internal override 
        public virtual void ItemAdded(Behavior item)
        {
            throw new NotImplementedException();
        }

        // internal override 
        public virtual void ItemRemoved(Behavior item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}

#if INTERACT    // TODO

namespace System.Windows.Interactivity
{
    // static class : System.Windows.Interactivity.Interaction
    //public static BehaviorCollection GetBehaviors(DependencyObject obj);
    //public static TriggerCollection GetTriggers(DependencyObject obj);

    public abstract class Behavior2<T> : Behavior2 where T : DependencyObject
    {
        public Behavior2() : base() { }

        public override void Attach(DependencyObject associatedObject)
        {
            base.Attach(associatedObject);
        }

        public new T AssociatedObject { get { return base.AssociatedObject as T; } }
        // protected T AssociatedObject { get; set; }
        //{
        //    get { return base.AssociatedObject as T; }
        //}

        protected override void OnAttached()
        {
            // base.OnAttached();
            if (this.AssociatedObject == null)
                throw new InvalidOperationException("AssociatedObject is not of the right type");
        }
    }

    // System.Windows.Media.Animation.Animatable

    public abstract class Behavior2 : Animatable, IAttachedObject2, IAttachedObject
    {
        // public abstract DependencyObject // IAttachedObject2.AssociatedObject { get; }
        // DependencyObject IBehavior2.AssociatedObject
        public DependencyObject AssociatedObject
        {
            get { return this._associatedObject; }
        }

        protected Type AssociatedType { get; }

        // protected override Freezable CreateInstanceCore();
        // protected abstract new Freezable CreateInstanceCore(); // { return base.CreateInstanceCore();  }

        protected abstract void OnAttached();
        protected abstract void OnDetaching();

        public virtual void Attach(DependencyObject associatedObject)
        {
            _associatedObject = associatedObject;
            OnAttached();
        }

        public virtual void Detach()
        {
            OnDetaching();
        }

        protected DependencyObject _associatedObject { get; set; }

    }

    public interface IAttachedObject2
    {
        DependencyObject AssociatedObject { get; }

        void Attach(DependencyObject dependencyObject);
        void Detach();
    }

    public interface IBehavior2 : IAttachedObject
    {
        // void Execute<T>(T data);
    }


    public abstract class BehaviorObj : DependencyObject, IBehavior2, IAttachedObject2
    {
        protected virtual void OnAttached() { }
        protected virtual void OnDetaching() { }

        public void Attach(DependencyObject associatedObject)
        {
            _associatedObject = associatedObject;
            OnAttached();
        }

        public void Detach()
        {
            OnDetaching();
        }

        protected DependencyObject _associatedObject { get; set; }

        // DependencyObject IBehavior2.AssociatedObject
        public DependencyObject AssociatedObject
        {
            get { return this._associatedObject; }
        }
    }


    public abstract class BehaviorDroid<T> where T : class
        // View where T : View
    {
        int _viewId;

        protected BehaviorDroid() // Context context, IAttributeSet attrs)
                                  // : base(context, attrs)
        {
            //_viewId = context.ObtainStyledAttributes(attrs,
            //    Resource.Styleable.Behavior).GetResourceId(Resource.Styleable.Behavior_View, -1);
        }

        protected virtual // override 
            void OnAttachedToWindow()
        {
            //base.OnAttachedToWindow();
            //View = RootView.FindViewById<T>(_viewId);
            OnAttached();
        }
        protected
            virtual // override 
            void OnDetachedFromWindow()
        {
            //base.OnDetachedFromWindow();
            OnDetached();
        }

        public abstract void OnAttached();
        public abstract void OnDetached();

        public T View
        {
            get;
            private set;
        }
    }
}

namespace System.Windows.Forms.Design.Behavior
{
    public abstract class DrawingBehavior
    {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected DrawingBehavior() { }
        protected DrawingBehavior(bool callParentBehavior, BehaviorService behaviorService) { }

        public virtual Cursor Cursor { get; }
        public virtual bool DisableAllCommands { get; }

        public abstract MenuCommand FindCommand(CommandID commandId);

        //public virtual void OnDragDrop(Glyph g, DragEventArgs e);
        //public virtual void OnDragEnter(Glyph g, DragEventArgs e);
        //public virtual void OnDragLeave(Glyph g, EventArgs e);
        //public virtual void OnDragOver(Glyph g, DragEventArgs e);
        //public virtual void OnGiveFeedback(Glyph g, GiveFeedbackEventArgs e);
        //public virtual void OnLoseCapture(Glyph g, EventArgs e);
        //public virtual bool OnMouseDoubleClick(Glyph g, MouseButtons button, Point mouseLoc);
        //public virtual bool OnMouseDown(Glyph g, MouseButtons button, Point mouseLoc);
        //public virtual bool OnMouseEnter(Glyph g);
        //public virtual bool OnMouseHover(Glyph g, Point mouseLoc);
        //public virtual bool OnMouseLeave(Glyph g);
        //public virtual bool OnMouseMove(Glyph g, MouseButtons button, Point mouseLoc);
        //public virtual bool OnMouseUp(Glyph g, MouseButtons button);
        //public virtual void OnQueryContinueDrag(Glyph g, QueryContinueDragEventArgs e);
    }

    public sealed class BehaviorService : IDisposable
    {
        // Drawing.dll
        //public Graphics AdornerWindowGraphics { get; }

        public DrawingBehavior // Behavior 
                    CurrentBehavior
        { get; }

        public event EventHandler Synchronize;
        //public BehaviorServiceAdornerCollection Adorners { get; }
        //public event BehaviorDragDropEventHandler BeginDrag;
        //public event BehaviorDragDropEventHandler EndDrag;

        //public Point AdornerWindowPointToScreen(Point p);
        //public Point AdornerWindowToScreen();
        //public Rectangle ControlRectInAdornerWindow(Control c);
        //public Point ControlToAdornerWindow(Control c);
        public void Dispose() { }
        //public Behavior GetNextBehavior(Behavior behavior);
        //public void Invalidate();
        //public void Invalidate(Region r);
        //public void Invalidate(Rectangle rect);
        //public Point MapAdornerWindowPoint(IntPtr handle, Point pt);
        //public Behavior PopBehavior(Behavior behavior);
        //public void PushBehavior(Behavior behavior);
        //public void PushCaptureBehavior(Behavior behavior);
        //public Point ScreenToAdornerWindow(Point p);
        //public void SyncSelection();
    }

}

#endif