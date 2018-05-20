#!/bin/bash
#===  FUNCTION  ================================================================
#         NAME: pad
#  DESCRIPTION: Pad $text on the $side with $char characters to length $length
#   PARAMETERS: 1 - the text string to pad (no default)
#               2 - how long the padded string is to be (default 80)
#               3 - the character to pad with (default '-')
#               4 - the side to pad on, L or R  or C for centre (default R)
#      RETURNS: Nothing
#===============================================================================
pad () {
    local text=${1?Usage: pad text [length] [character] [L|R|C]}
    local length=${2:-80}
    local char=${3:--}
    local side=${4:-R}
    local line l2
    #
    [ ${#text} -ge $length ] && { echo "$text"; return; }
    #
    char=${char:0:1}
    side=${side^^}
    #
    printf -v line "%*s" $(($length - ${#text})) ' '
    line=${line// /$char}
    #
    if [[ $side == "R" ]]; then
        echo "${text}${line}"
        elif [[ $side == "L" ]]; then
        echo "${line}${text}"
        elif [[ $side == "C" ]]; then
        l2=$((${#line}/2))
        echo "${line:0:$l2}${text}${line:$l2}"
    fi
}

projects=(
    "Convert from Base-10 to Base-N"
    "Convert from Base-N to Base-10"
    "Unicode Characters"
    "Character Multiplier"
    "Magic Exchangeable Words"
    "Sum Big Numbers"
    "Multiply Big Number"
    "Letters Change Numbers"
    "Melrah Shake"
)

current=1
for i in "${projects[@]}"
do
    project=${i,,} #Lowercase
    project=${project//\ /-} #Replace spaces with dashes
    index=$(pad $current 2 0 L)
    #
    echo $index-$project
    # dotnet new console -o $index-$project
    ((current++))
done