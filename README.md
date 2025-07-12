# 🎮 Mastermind Console Game – C# Implementation

## 👋 About the Project

This project is a PC-based implementation of the classic **Mastermind** game, written in **C#**, built as part of a technical assessment.


---

## 🧠 Game Rules

- The game randomly generates a **secret code** of 4 distinct digits chosen from `'0'` to `'8'`.
- The player has **10 attempts** (or a custom number via command line) to guess the code.
- After each guess, the program provides feedback:
  - **Well-placed pieces**: correct digits in the correct position.
  - **Misplaced pieces**: correct digits in the wrong position.
- The game ends when:
  - The player correctly guesses the code → **"Congratz! You did it!"**
  - The player runs out of attempts.
  - The user exits with `Ctrl + C` or  `Ctrl + Z`(EOF signal).

---

## ⚙️ How to Run

### ✅ Requirements

- OS: Windows
- .NET SDK: [.NET 6.0 or later](https://dotnet.microsoft.com/en-us/download)
- Terminal / Command Prompt

### ▶️ Run Instructions

1. Open the terminal in the project folder.
2. Run the program:
  dotnet run -- -c 1234 -t 10
  `-c [CODE]`: Optional. Manually provide a secret code.
  `-t [ATTEMPTS]`: Optional. Set a custom number of attempts (default is 10).

