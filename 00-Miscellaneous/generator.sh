#!/bin/bash

#===  FUNCTION  ================================================================
#         NAME: pad
#  DESCRIPTION: Pad $text on the $side with $char characters to length $length
#   PARAMETERS: 1 - the text string to pad (no default)
#               2 - how long the padded string is to be (default 80)
#               3 - the character to pad with (default '-')
#===============================================================================
pad () {
    local text=${1?Usage: pad text [length] [character] [L|R|C]}
    local length=${2:-80}
    local char=${3:--}
    local line l2
    #
    [ ${#text} -ge $length ] && { echo "$text"; return; }
    #
    char=${char:0:1}
    #
    printf -v line "%*s" $(($length - ${#text})) ' '
    line=${line// /$char}
    #
    echo "${line}${text}"
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

index=1
for i in "${projects[@]}"
do
    indexLength=$((2-${#index}))
    nameLowercase=${i,,}
    nameHyphenized=${nameLowercase//\ /-}
    nameUnpadded=$index-$nameHyphenized
    padding=$((indexLength+${#nameUnpadded}))
    namePadded=$(pad $nameUnpadded $padding '0')
    #
    echo $namePadded
    ((index++))
    # dotnet new console -o ${namePadded}
    # echo ${padding} - ${#nameUnpadded} - ${indexLength} - ${#i}
done