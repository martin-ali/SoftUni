cd /home/tectonik/Desktop/SoftUni/02-tech/03-programming-fundamentals/12-exam-preparation/
for fd in */; do
  #get lowercase version
  fd_lower=$(printf %s "$fd" | tr A-Z a-z)
  #if it wasn't already lowercase, move it.
  [ "$fd" != "$fd_lower" ] && mv "$fd" "$fd_lower"
done