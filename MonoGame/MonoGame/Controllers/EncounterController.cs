﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    class EncounterController : IController
    {
        private KeyboardState keyboardState;
        private ICommands currentCommand;
        private Dictionary<Keys, ICommands> commandLibrary;

        public EncounterController(EncounterGUI menu)
        {
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.Up, currentCommand = new EncounterUpCommand(menu));
            commandLibrary.Add(Keys.Down, currentCommand = new EncounterDownCommand(menu));
            commandLibrary.Add(Keys.Left, currentCommand = new EncounterLeftCommand(menu));
            commandLibrary.Add(Keys.Right, currentCommand = new EncounterRightCommand(menu));
            commandLibrary.Add(Keys.Enter, currentCommand = new EncounterSelectCommand(menu));
        }

        public void Update()
        {
            currentCommand = new NullCommand();
            keyboardState = Keyboard.GetState();
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (commandLibrary.ContainsKey(key))
                {
                    currentCommand = commandLibrary[key];
                    currentCommand.Execute();
                    break;
                }
            }
        }
    }
}
