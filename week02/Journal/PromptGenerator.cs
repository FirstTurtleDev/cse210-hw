using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts = new()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one small win I had today?",
        "What did I learn today?",
        "What is something I am grateful for right now?"
    };

    private readonly Random _random = new();
    private int _lastIndex = -1;

    
    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0) return "Write anything you want today:";
        int idx;
        do { idx = _random.Next(_prompts.Count); }
        while (_prompts.Count > 1 && idx == _lastIndex);
        _lastIndex = idx;
        return _prompts[idx];
    }
}
