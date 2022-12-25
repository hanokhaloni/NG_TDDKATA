Note : THIS IS NOT A KATA!

The idea here is to have 8 meetings around the FizzBuzz question and do the following:
1. Do the initial commit and setup (committed code needs to compile a test)
2. Do the test ramp up and CI (comitted code should run test on server side or a pre-commit hook) - make sure CI is defined per branch
3. Solve the kata (non TDD) - in a new branch
4. Solve the kata (TDD) - in a new branch - compare to last 
5. Solve the kata (TDD) - again - in a new branch - compare to last
6. Remodel the solution (do a little design, go back to code at end of step 2) - non tdd - in a new branch
7. Remodel the solution (do a little design, go back to code at end of step 4, use existing tests but delete the code) - tdd - in a new branch
8. Compare the branches at steps 3,4,5,6,7 - and decide which to merge to master.