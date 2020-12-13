import sys
import re


class rule:
    def __init__(self, countLow, countHigh, letter, password):
        self.countLow = int(countLow)
        self.countHigh = int(countHigh)
        self.letter = letter
        self.password = password

    def IsValid(self):
        return (self.password.count(self.letter) >= self.countLow and
                self.password.count(self.letter) <= self.countHigh)

    def IsValidPart2(self):
            return (self.countLow - 1 < len(self.password) and self.countHigh - 1 < len(self.password) and
                     ((self.password[self.countLow - 1]  == self.letter) ^
                     (self.password[self.countHigh - 1] == self.letter)))
def main():
    file = open(r'D:\Users\scott\Desktop\paswordadvententries.txt')
    entries = file.readlines()
    rules = []

    for entry in entries:
        countLow    = re.split(r'-|\s|:', entry)[0]
        countHigh   = re.split(r'-|\s|:', entry)[1]
        letter      = re.split(r'-|\s|:', entry)[2]
        password    = re.split(r'-|\s|:', entry)[4]

        rules.append(rule(countLow, countHigh, letter, password))

    # Doing check seperate from creation of rules
    # since it makes me feel safer.
    validRulesPart1 = 0
    validRulesPart2 = 0
    for ruleEntry in rules:
        if(ruleEntry.IsValid()):
            validRulesPart1 += 1
        if(ruleEntry.IsValidPart2()):
            validRulesPart2 += 1
        

    print("Valid Rule Count for Part 1: ", validRulesPart1)
    print("Valid Rule Count for Part 2: ", validRulesPart2)

main()