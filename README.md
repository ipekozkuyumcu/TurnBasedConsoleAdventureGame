# Turn-Based-Console-Adventure-Game-with-C#

This console game project is a combat game. The player is a mage and encounters monsters one by one in an endless dungeon. 
There are two types of enemies generated randomly. One of them is magic resistent, the other one is not. 
Enemies have health and attack stats. 
The player has health, mana, level and attack stats. 
Enemies have one ability: Apply damage. 
The player has five abilities: Sword Attack (hits the enemy with the player's current attack value), Magic Strike (hits the enemy with the player's current attack value + 2, and costs 5 mana), Poison Spell (hits the enemy with the player's current attack value + 2, and costs 15 mana, but the enemy can't hit back), Healing Spell (restores 10 health to the player, and costs 7 mana), Restore Mana (Restores 10 mana to the player). 
The player can't use magic or spell on magic resistent enemies. If they try to use, they will fail to apply damage to it, but will get hit by the enemy. 
Base enemy stats are: 100 health, 10 attack. 
Base player stats are: 500 health, 200 mana, 20 attack, level 1. 
After every player movement, one round will pass and the enemy will gain + 2 attacks. 
Enemies will keep attack value buffs, and the next created enemy will always have the last enemies final attack stat. 
After the players kills an enemy they will gain + 1 level, and their enemies slain score will increase + 1. 
After each level increase player can choose a buff: To gain 50 health, to gain 25 mana, or to gain 10 attack. 
Each enemy created will have 100 + (player level + 2) healt. 
Game continues untill the player dies. 
Final score will be the number of enemies slain. 
