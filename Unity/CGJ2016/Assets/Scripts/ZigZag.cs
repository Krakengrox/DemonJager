
public class ZigZag
{

    #region Variables
    float[] DivisionLimits = null;
    int Divisions = 0;
    #endregion

    public ZigZag(float lowerClamp, float upperClamp, int divisions)
    {
        this.DivisionLimits = CreateDivisionLimits(lowerClamp, upperClamp, divisions);
        this.Divisions = divisions;
    }

    float[] CreateDivisionLimits(float minAngle, float maxAngle, int numberOfDivisions)
    {
        float[] temp = null;
        float step = 0.0f;

        temp = new float[numberOfDivisions + 1];
        step = (maxAngle - minAngle) / numberOfDivisions;

        for (int i = numberOfDivisions; i >= 0; i--)
        {
            temp[i] = (i * step) + minAngle;
        }

        return temp;
    }

    public int CalculateDivision(float angle)
    {
        int temp = 0;

        for (int i = DivisionLimits.Length - 1; i >= 1; i--)
        {
            if ((angle <= DivisionLimits[i]) && (angle > DivisionLimits[i - 1]))
            {
                temp = i;
                break;
            }
        }
        return temp;
    }


    public int NextDivision(int currentDivision)
    {
        int temp = 0;

        //increment current division
        temp = ++currentDivision;

        //if the next division is equal or greater to the number of divisions (because the length of the array is +1 grater than the number of divisions), the next division is the one previous to the limit.
        if (temp >= this.DivisionLimits.Length)
        {
            temp = this.DivisionLimits.Length - 2;
        }

        return temp;
    }

    public int PreviousDivision(int currentDivision)
    {
        int temp = 0;

        //increment current division
        temp = --currentDivision;

        //if the next division is equal or greater to the number of divisions (because the length of the array is +1 grater than the number of divisions), the previous division is the second.
        if (temp <= 1)
        {
            temp = 2;
        }

        return temp;
    }

    public int NextDivision(int currentDivision, bool direction, int stepsInThatDirection)
    {
        for (int i = stepsInThatDirection - 1; i >= 0; i--)
        {
            if (direction)
            {
                if (currentDivision >= this.DivisionLimits.Length - 1)
                {
                    direction = !direction;
                    i++;
                }
                else
                {
                    currentDivision++;
                }
            }
            else
            {
                if (currentDivision <= 1)
                {
                    direction = !direction;
                    i++;
                }
                else
                {
                    currentDivision--;
                }
            }
        }
        return currentDivision;
    }

    //public int PreviousDivision(int currentDivision, int steps)
    //{
    //    int temp = 0;
    //    int diff = 0;
    //    int res = 0;
    //    int div = 0;


    //    div = steps / this.Divisions;
    //    res = steps / div;

    //    for (int i = div - 1; i >= 0; i--)
    //    {
    //        diff =
    //    }

    //    //increment current division
    //    temp = currentDivision - steps;

    //    if (temp <= 1)
    //    {
    //        temp = 2;
    //    }

    //    return temp;
    //}

    public void GetDivisionLimits(int division, out float lowerLimit, out float upperLimit)
    {
        lowerLimit = this.DivisionLimits[division - 1];
        upperLimit = this.DivisionLimits[division];
    }
}
