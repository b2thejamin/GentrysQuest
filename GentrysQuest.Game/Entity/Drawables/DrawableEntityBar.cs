using GentrysQuest.Game.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace GentrysQuest.Game.Entity.Drawables;

public partial class DrawableEntityBar : CompositeDrawable
{
    // objects
    private readonly ProgressBar healthProgressBar;
    private SpriteText entityName;
    private SpriteText entityLevel;

    public DrawableEntityBar(Entity entity)
    {
        Anchor = Anchor.TopCentre;
        Origin = Anchor.BottomCentre;
        RelativeSizeAxes = Axes.Both;
        RelativePositionAxes = Axes.Both;
        Y -= 0.1f;
        Size = new Vector2(1.25f, 0.125f);
        InternalChildren = new Drawable[]
        {
            entityName = new SpriteText
            {
                Text = entity.Name,
                Anchor = Anchor.TopCentre,
                Origin = Anchor.BottomCentre,
                Font = FontUsage.Default.With(size: 50)
            },
            new Container
            {
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    new Container
                    {
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        Child = entityLevel = new SpriteText
                        {
                            Text = entity.Experience.Level.Current.Value.ToString(),
                            Anchor = Anchor.CentreRight,
                            Origin = Anchor.CentreRight
                        }
                    },
                    healthProgressBar = new ProgressBar(0, entity.Stats.Health.Total())
                    {
                        RelativeSizeAxes = Axes.X,
                        Anchor = Anchor.CentreRight,
                        Origin = Anchor.CentreRight,
                        Size = new Vector2(0.98f, 10)
                    }
                }
            }
        };
        healthProgressBar.ForegroundColour = Colour4.Lime;
        healthProgressBar.BackgroundColour = Colour4.Red;

        entity.OnHealthEvent += delegate { healthProgressBar.Current = entity.Stats.Health.Current.Value; };
        entity.OnUpdateStats += delegate
        {
            entityLevel.Text = entity.Experience.Level.Current.Value.ToString();
            healthProgressBar.Current = entity.Stats.Health.Current.Value;
            healthProgressBar.Max = entity.Stats.Health.Total();
        };
    }
}
