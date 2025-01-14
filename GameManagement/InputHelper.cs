﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class InputHelper
{
    private const int SCROLL_WHEEL_VALUE_PER_SCROLL_TICK = 120;
    protected MouseState currentMouseState, previousMouseState;
    protected KeyboardState currentKeyboardState, previousKeyboardState;
    protected Vector2 scale, offset;

    public InputHelper()
    {
        scale = Vector2.One;
        offset = Vector2.Zero;
    }

    public void Update()
    {
        previousMouseState = currentMouseState;
        previousKeyboardState = currentKeyboardState;
        currentMouseState = Mouse.GetState();
        currentKeyboardState = Keyboard.GetState();
    }

    public KeyboardState CurrentKeyboardState
    {
        get { return currentKeyboardState; }
    }


    public Vector2 Scale
    {
        get { return scale; }
        set { scale = value; }
    }

    public Vector2 Offset
    {
        get { return offset; }
        set { offset = value; }
    }

    public Vector2 MousePosition
    {
        get { return (new Vector2(currentMouseState.X, currentMouseState.Y) - offset) / scale; }
    }

    public float TotalScrollWheelValue
    {
        get { return currentMouseState.ScrollWheelValue / SCROLL_WHEEL_VALUE_PER_SCROLL_TICK; }
    }

    public float FrameScrollWheelValue
    {
        get { return (currentMouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue) / SCROLL_WHEEL_VALUE_PER_SCROLL_TICK; }
    }

    public bool MouseLeftButtonPressed()
    {
        return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
    }

    public bool MouseLeftButtonDown()
    {
        return currentMouseState.LeftButton == ButtonState.Pressed;
    }

    public bool KeyPressed(Keys k)
    {
        return currentKeyboardState.IsKeyDown(k) && previousKeyboardState.IsKeyUp(k);
    }

    public bool IsKeyDown(Keys k)
    {
        return currentKeyboardState.IsKeyDown(k);
    }

    public bool AnyKeyPressed
    {
        get { return currentKeyboardState.GetPressedKeys().Length > 0 && previousKeyboardState.GetPressedKeys().Length == 0; }
    }
}