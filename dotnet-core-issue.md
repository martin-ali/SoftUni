 
# Cause

- ncurses package v6.1 is the cause
- Downgrading to ~6.0 helps

# Fix

- Waiting

# Method of temporary avoidal

- Using "TERM=xterm dotnet \[command\]" as opposed to "dotnet \[command\]"
- Temporarily set environment variable with command "export TERM=xterm dotnet"
- Not sure exactly what it does
- Probably a bad idea
- Should wipe OS after this

