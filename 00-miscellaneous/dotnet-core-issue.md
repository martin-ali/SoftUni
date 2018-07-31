
# Issues encountered with DotNet Core

## Dotnet run fails

### Cause

- ncurses package v6.1 is the cause
- Downgrading to ~6.0 helps

### Fix

- Waiting

### Methods of temporary avoidance

- Using "TERM=xterm dotnet \[command\]" as opposed to "dotnet \[command\]"
- Downgrading to ncurses 6.0.4

## VS Code Omnisharp fails

### Description

- Omnisharp fails after detecting Mono

### Cause

- Some kind of conflict with Mono

### Methods of temporary avoidance

- Delete Mono