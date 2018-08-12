using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Yugioh
{
    class SpriteManager
    {
        // GameBoard stuff
        public Texture2D gameMat;
        public Texture2D cardBack;

        // Cards 
        public Texture2D mysticalElf;
        public Texture2D feralImp;
        public Texture2D wingedDragonGuardianOfTheFortress1;
        public Texture2D summonedSkull;
        public Texture2D beaverWarrior;
        public Texture2D darkMagician;
        public Texture2D gaiaTheFierceKnight;
        public Texture2D curseOfDragon;
        public Texture2D celticGuardian;
        public Texture2D mammothGraveyard;
        public Texture2D greatWhite;
        public Texture2D silverFang;
        public Texture2D giantSoldierOfStone;
        public Texture2D dragonZombie;
        public Texture2D domaTheAngelOfSilence;
        public Texture2D ansatsu;
        public Texture2D wittyPhantom;
        public Texture2D clawReacher;
        public Texture2D mysticClown;
        public Texture2D swordOfDarkDestruction;
        public Texture2D bookOfSecretArts;
        public Texture2D darkHole;
        public Texture2D dianKetoTheCureMaster;
        public Texture2D ancientElf;
        public Texture2D magicalGhost;
        public Texture2D fissure;
        public Texture2D trapHole;
        public Texture2D twoProngedAttack;
        public Texture2D deSpell;
        public Texture2D monsterReborn;
        public Texture2D reinforcements;
        public Texture2D changeOfHeart;
        public Texture2D theSternMystic;
        public Texture2D wallOfIllusion;
        public Texture2D neoTheMagicSwordsman;
        public Texture2D baronOfTheFiendSword;
        public Texture2D manEatingTreasureChest;
        public Texture2D sorcererOfTheDoomed;
        public Texture2D lastWill;
        public Texture2D waboku;
        public Texture2D soulExchange;
        public Texture2D cardDestruction;
        public Texture2D trapMaster;
        public Texture2D dragonCaptureJar;
        public Texture2D yami;
        public Texture2D manEaterBug;
        public Texture2D reverseTrap;
        public Texture2D removeTrap;
        public Texture2D castleWalls;
        public Texture2D ultimateOffering;

        public SpriteManager(ContentManager content)
        {
            // GameBoard stuff
            gameMat = content.Load<Texture2D>("images/player_mat");
            cardBack = content.Load<Texture2D>("images/card_back");

            // Cards
            mysticalElf = content.Load<Texture2D>("images/mystical_elf");
            feralImp = content.Load<Texture2D>("images/feral_imp");
            wingedDragonGuardianOfTheFortress1 = content.Load<Texture2D>("images/winged_dragon_guardian_of_the_fortress_1");
            summonedSkull = content.Load<Texture2D>("images/summoned_skull");
            beaverWarrior = content.Load<Texture2D>("images/beaver_warrior");
            darkMagician = content.Load<Texture2D>("images/dark_magician");
            gaiaTheFierceKnight = content.Load<Texture2D>("images/gaia_the_fierce_knight");
            curseOfDragon = content.Load<Texture2D>("images/curse_of_dragon");
            celticGuardian = content.Load<Texture2D>("images/celtic_guardian");
            mammothGraveyard = content.Load<Texture2D>("images/mammoth_graveyard");
            greatWhite = content.Load<Texture2D>("images/great_white");
            silverFang = content.Load<Texture2D>("images/silver_fang");
            giantSoldierOfStone = content.Load<Texture2D>("images/giant_soldier_of_stone");
            dragonZombie = content.Load<Texture2D>("images/dragon_zombie");
            domaTheAngelOfSilence = content.Load<Texture2D>("images/doma_the_angel_of_silence");
            ansatsu = content.Load<Texture2D>("images/ansatsu");
            wittyPhantom = content.Load<Texture2D>("images/witty_phantom");
            clawReacher = content.Load<Texture2D>("images/claw_reacher");
            mysticClown = content.Load<Texture2D>("images/mystic_clown");
            swordOfDarkDestruction = content.Load<Texture2D>("images/sword_of_dark_destruction");
            bookOfSecretArts = content.Load<Texture2D>("images/book_of_secret_arts");
            darkHole = content.Load<Texture2D>("images/dark_hole");
            dianKetoTheCureMaster = content.Load<Texture2D>("images/dian_keto_the_cure_master");
            ancientElf = content.Load<Texture2D>("images/ancient_elf");
            magicalGhost = content.Load<Texture2D>("images/magical_ghost");
            fissure = content.Load<Texture2D>("images/fissure");
            trapHole = content.Load<Texture2D>("images/trap_hole");
            twoProngedAttack = content.Load<Texture2D>("images/two_pronged_attack");
            deSpell = content.Load<Texture2D>("images/de-spell");
            monsterReborn = content.Load<Texture2D>("images/monster_reborn");
            reinforcements = content.Load<Texture2D>("images/reinforcements");
            changeOfHeart = content.Load<Texture2D>("images/change_of_heart");
            theSternMystic = content.Load<Texture2D>("images/the_stern_mystic");
            wallOfIllusion = content.Load<Texture2D>("images/wall_of_illusion");
            neoTheMagicSwordsman = content.Load<Texture2D>("images/neo_the_magic_swordsman");
            baronOfTheFiendSword = content.Load<Texture2D>("images/baron_of_the_fiend_sword");
            manEatingTreasureChest = content.Load<Texture2D>("images/man-eating_treasure_chest");
            sorcererOfTheDoomed = content.Load<Texture2D>("images/sorcerer_of_the_doomed");
            lastWill = content.Load<Texture2D>("images/last_will");
            waboku = content.Load<Texture2D>("images/waboku");
            soulExchange = content.Load<Texture2D>("images/soul_exchange");
            cardDestruction = content.Load<Texture2D>("images/card_destruction");
            trapMaster = content.Load<Texture2D>("images/trap_master");
            dragonCaptureJar = content.Load<Texture2D>("images/dragon_capture_jar");
            yami = content.Load<Texture2D>("images/yami");
            manEaterBug = content.Load<Texture2D>("images/man-eater_bug");
            reverseTrap = content.Load<Texture2D>("images/reverse_trap");
            removeTrap = content.Load<Texture2D>("images/remove_trap");
            castleWalls = content.Load<Texture2D>("images/castle_walls");
            ultimateOffering = content.Load<Texture2D>("images/ultimate_offering");
        }
    }
}