﻿namespace GentrysQuest.Game.Entity
{
    public class Experience(Xp xp, Level level)
    {
        public Xp Xp { get; } = xp;
        public Level Level { get; } = level;

        public Experience()
            : this(new Xp(), new Level())
        {
        }

        public int CurrentLevel() => Level.Current.Value;

        public int CurrentXp() => Xp.Current.Value;

        public override string ToString()
        {
            return $"{Level} {Xp}";
        }
    }
}
