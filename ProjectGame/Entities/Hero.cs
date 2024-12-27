using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace ProjectGame.Entities
{
    enum CStates { IDLE, RUNNING, JUMPING, SHOOTING, SLIDE, RUNSHOOTING, DUCK, HURT}
    class Hero
    {
        private static Hero uniqueInstance = new Hero();
        
        private CStates state;
        private Dictionary<CStates, Texture2D> spritesheets;
        private Dictionary<CStates, int> framecounts;

        private int frameWidth;
        private int frameHeight;

        private Hero() {
            state = CStates.IDLE;
        }
        public static Hero getHero()
        {
            return uniqueInstance;
        }

        public void LoadAnimations(ContentManager content)
        {
            spritesheets[CStates.IDLE] = content.Load<Texture2D>("Animations/player-idle");

            framecounts[CStates.IDLE] = 6;

            frameHeight = spritesheets[CStates.IDLE].Height;
            frameWidth = spritesheets[CStates.IDLE].Width / framecounts[CStates.IDLE];
        }

        public void ChangeState(CStates newState)
        {
                state = newState;
        }
    }
}
