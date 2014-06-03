using System;

public class CSharpExam : Exam
{
    private int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        private set
        {
            if (0 > value || value > 100)
            {
                throw new ArgumentException("score","Exam score cannot be negative or greager than 100.");
            }
            this.score = value;
        }
    }

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        
    }
}