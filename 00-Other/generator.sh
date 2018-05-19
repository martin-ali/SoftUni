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

items=(
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

len=${#items[@]}
# echo ${#items[@]}

# for i in ${items[@]}
for i in {0..8}
do
    projectNumber=$(($i+1))
    indexLength=$((2-${#projectNumber}))
    nameLowercase=${items[$i],,}
    nameHyphenized=${nameLowercase//\ /-}
    nameUnpadded=$(($projectNumber))-${nameHyphenized}
    padding=$((indexLength+${#nameUnpadded}))
    namePadded=$(pad ${nameUnpadded} ${padding} '0')
    #
    echo ${namePadded}
    # echo ${padding} - ${#nameUnpadded} - ${indexLength} - ${#i}
    # dotnet new console -o $(($i+1))-${items[$i]}
done