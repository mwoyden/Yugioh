﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.TrapCards
{
    class DragonCaptureJar : TrapCard
    {
        public DragonCaptureJar(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.dragonCaptureJar;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Dragon Capture Jar";
            cardText = "Change all face-up Dragon-Type monsters on the field to Defense Position, also they cannot change their battle positions.";
            trapType = TrapType.CONTINUOUS;
        }
    }
}
