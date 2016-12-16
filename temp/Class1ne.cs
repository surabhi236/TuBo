using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Threading.Tasks;

namespace temp2
{
    [LuisModel("c729d3c8-35ba-4fdf-ad89-def5103abd5f", "c97c0be3d8cb4aac87641f0eba24532f")]
    [Serializable]
 
    public class luisdialog : LuisDialog<object>
    {
        
        public const string NUM = "builtin.number";
        public const string ADD = "operator::add";
        public const string SUB = "operator::subtract";
        public const string MUL = "operator::multiply";
        public const string DIV = "operator::divide";

        public int power(int a)
        {
            int ret = 1;
            for (int i = 0; i < a; i++)
                ret *= 10;
            return ret;
        }
        [LuisIntent("greet")]
        public async Task greet(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("**Hello, I am TuBo**. I am your Mathemetics tutor.I am pretty good in the fields of  :   \n**1**.How to solve basic problems in whole numbers. in  \n \ta.Addition  \n  \tb.Subtraction  \n  \tc.Multiplication  \n  \td.Division  \n**2**.How to solve linear equations \n(write it in ax+b=c form where a,c are positive integers)  \n**3**.To find area of square and rectangle  \n(give dimensions like side1,side2 even in square)   \n**4**.To find perimeter of square and rectangle  \n(give dimensions like side1,side2 even in square)  ");
            await context.PostAsync("**Give me a try, :)**");
            context.Wait(MessageReceived);
        }

        [LuisIntent("None")]
        public async Task none(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I am your Tutor. I am not here to chat. Send me your problem.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("area")]
        public async Task area(IDialogContext context, LuisResult result)
        {
            string a1 = result.Entities[0].Entity;
            string b1 = result.Entities[1].Entity;
            int a = int.Parse(a1);
            int b = int.Parse(b1);
            await context.PostAsync("**Remember**, I wil help you reach till the answer to your problem but will *not* give you the final answer. work the steps out on a paper and be patient. **Happy solving **:) ");
            if (a!=b)
            {
                await context.PostAsync($"To calculate area of rectangle calculate {a}*{b}. so, finally {a * b} is the area of square.");
            }
            else
            {
                await context.PostAsync($"To calculate area of square calculate {a}*{a}. so, finally {a * a} is the area of square.");
            }
            context.Wait(MessageReceived);

        }

        [LuisIntent("perimeter")]
        public async Task peri(IDialogContext context, LuisResult result)
        {
            string a1 = result.Entities[0].Entity;
            int a = int.Parse(a1);
            string b1 = result.Entities[1].Entity;
            int b = int.Parse(b1);
            await context.PostAsync("**Remember**, I wil help you reach till the answer to your problem but will *not* give you the final answer. work the steps out on a paper and be patient. **Happy solving **:) ");
            if (a!=b)
            {
                await context.PostAsync($"To calculate perimeter of rectangle calculate 2*({a}+{b}). So, finally {2 * (a + b)} is the area of rectangle.");
            }
            else
            {
                await context.PostAsync($"To calculate perimeter of square calculate 4*({a}). So, finally {4 * a} is the area of square.");
            }
            context.Wait(MessageReceived);
        }


        [LuisIntent("linear")]
        public async Task linear(IDialogContext context, LuisResult result)
        {
            EntityRecommendation title1;
            await context.PostAsync("**Remember**, I wil help you reach till the answer to your problem but will *not* give you the final answer. work the steps out on a paper and be patient. **Happy solving **:) ");
            string a1 = result.Entities[0].Entity;
            string b1 = result.Entities[1].Entity;
            string c1 = result.Entities[2].Entity;

            int a = int.Parse(a1);
            int b = int.Parse(b1);
            int c = int.Parse(c1);

            if (result.TryFindEntity(ADD, out title1))
            {
                await context.PostAsync($"Subtract {b} from {c} and divide {c-b} by {a} to obtain the value of the variable.");
            }
            else if (result.TryFindEntity(SUB, out title1))
            {
                await context.PostAsync($"Add {b} to {c} and divide {c + b} by {a} to obtain the value of the variable.");
            }
            await context.PostAsync("*If you want to learn how to perform basic operations on 2 nos. then type a problem statement accordingly*");
            context.Wait(MessageReceived);
        }

        [LuisIntent("help")]
        public async Task hel(IDialogContext context, LuisResult result)
        { int add=0, multi=0, divi=0, subt=0;
            EntityRecommendation title;
            if (result.TryFindEntity(ADD, out title))
                add++;
            if (result.TryFindEntity(SUB, out title))
                subt++;
            if (result.TryFindEntity(MUL, out title))
                multi++;
            if (result.TryFindEntity(DIV, out title))
                divi++;
            int step1 = 1;
            

            if (add != 0 && multi == 0 && divi == 0 && subt == 0)
            {
                if (result.TryFindEntity(ADD, out title))
                {
                    await context.PostAsync("**Remember**, I wil help you reach till the answer to your problem but will *not* give you the final answer. work the steps out on a paper and be patient. **Happy solving **:) ");
                    string a1 = result.Entities[0].Entity;
                    string b1 = result.Entities[1].Entity;
                    string c1 = result.Entities[2].Entity;

                    int max_digit = (a1.Length > b1.Length) ? a1.Length : b1.Length;
                    int a = int.Parse(a1);
                    int b = int.Parse(b1);
                    int c = a + b;
                    int div = 1;
                    int p, q, carry = 0, step = 1, prev = 0;
                    while (max_digit != 0)
                    {
                        p = (a / div) % 10;
                        q = (b / div) % 10;
                        carry = ((p + q + prev) / 10) % 10;
                        await context.PostAsync($"**STEP {step}**");
                        {
                            if (prev != 0)
                            {
                                await context.PostAsync($"Add {p} and {q}. It is {p + q}. But we have to add {prev} from previous step to {p + q} too which gives {p + q + prev} . Finally, {(p + q + prev) % 10} is your {div}'s place in answer.");
                            }
                            else
                            {
                                await context.PostAsync($"Add {p} and {q}. It is {p + q}. So, now {(p + q + prev) % 10} is your {div}'s place in answer.");
                            }
                        }
                        {
                            if (carry != 0)
                            {

                                await context.PostAsync($"Now you need to add the carry obtained , {carry} to sum of next place value digits.");
                                prev = carry;
                            }
                            else
                            {
                                prev = 0;
                            }
                        }
                        div *= 10;
                        step += 1;
                        max_digit--;
                    }
                    if (carry != 0)
                        await context.PostAsync($"Here we have a carry {carry} left. So that is your {div}'s digit.");

                    if (result.Entities[2].Type == NUM)
                        await context.PostAsync("*Hope you now understand the method correctly! \n We have shown you how to calculate for your first 2 nos. Now that you know how to add 2 nos, you just need to repeat the process by adding the sum of first to the next number. I'll insist you to try that yourself. All the best!*");
                    else
                        await context.PostAsync("*Hope you now understood the method. Don't hesitate to ask more queries, I'm there for you whenever you need :) *");
                }
            }
            else if (add == 0 && multi == 0 && divi == 0 && subt != 0)
            {
                await context.PostAsync("**Remember**, I wil help you reach till the answer to your problem but will *not* give you the final answer. work the steps out on a paper and be patient. **Happy solving **:) ");
                if (result.TryFindEntity(SUB, out title))
                {
                    string a1 = result.Entities[0].Entity;
                    string b1 = result.Entities[1].Entity;
                    string c1 = result.Entities[2].Entity;

                    int max_digit = (a1.Length > b1.Length) ? a1.Length : b1.Length;
                    int a = int.Parse(a1);
                    int b = int.Parse(b1);
                    int c = a + b;
                    int div = 1;
                    int p, q, borrow = 0, step = 1, q_prev, p_prev;

                    if (title.Entity == "-")
                    {
                        if (b > a)
                            await context.PostAsync($"We will first calculate {b}-{a} and then multiply the answer with -1.");
                        while (max_digit != 0)
                        {
                            await context.PostAsync($"**STEP {step}**");
                            if (a > b)
                            {
                                p = ((a / div) % 10) - borrow;
                                q = (b / div) % 10;
                                if (p > q || p == q)
                                {
                                    await context.PostAsync($"Calculate {p}-{q}. So, now {div}'s digit is {p - q}.");
                                    borrow = 0;
                                }
                                else
                                {
                                    borrow = 1;
                                    p_prev = (a / (div * 10)) % 10;
                                    await context.PostAsync($"Here since {q}>{p} , we need to borrow {borrow} from {p_prev} . So, now calculate {p + 10}-{q} which gives {p + 10 - q} as the {div}'s digit of your answer.Also remember {p_prev} now becomes {p_prev - 1}.");
                                }
                            }
                            if (b > a)
                            {
                                p = (a / div) % 10;
                                q = ((b / div) % 10) - borrow;
                                if (q > p || p == q)
                                {
                                    await context.PostAsync($"Calculate {q}-{p}. So, now {div}'s digit is {q - p}.");
                                    borrow = 0;
                                }
                                else
                                {
                                    borrow = 1;
                                    q_prev = (b / (div * 10)) % 10;
                                    await context.PostAsync($"Here since {p}>{q} , we need to borrow {borrow} from {q_prev} . So, now calculate {q + 10}-{p} which gives {q + 10 - p} as the {div}'s digit of your answer. Also remember {q_prev} now becomes {q_prev - 1}.");
                                }
                            }

                            step += 1;
                            div *= 10;
                            max_digit--;
                        }
                    }
                    else
                    {
                        if (a > b)
                            await context.PostAsync($"We will first calculate {a}-{b} and then multiply the answer with -1.");
                        while (max_digit != 0)
                        {
                            await context.PostAsync($"**STEP {step}**");
                            if (b > a)
                            {
                                p = (a / div) % 10;
                                q = ((b / div) % 10) - borrow;
                                if (q > p || p == q)
                                {
                                    await context.PostAsync($"Subtract {p} from {q}. So, now {div}'s digit is {q - p}.");
                                    borrow = 0;
                                }
                                else
                                {
                                    borrow = 1;
                                    p_prev = (a / (div * 10)) % 10;
                                    await context.PostAsync($"Here since {p}>{q} , we need to borrow {borrow} from {p_prev} . So, now calculate {p + 10}-{q} which gives {p + 10 - q} as the {div}'s digit of your answer.Also remember {p_prev} now becomes {p_prev - 1}.");
                                }
                            }
                            if (b < a)
                            {
                                p = ((a / div) % 10) - borrow;
                                q = ((b / div) % 10);
                                if (p > q || p == q)
                                {
                                    await context.PostAsync($"Subtract {q} from {p}. So, now {div}'s digit is {p - q}.");
                                    borrow = 0;
                                }
                                else
                                {
                                    borrow = 1;
                                    p_prev = (a / (div * 10)) % 10;
                                    await context.PostAsync($"Here since {q}>{p} , we need to borrow {borrow} from {p_prev} . So, now calculate {p + 10}-{q} which gives {q + 10 - p} as the {div}'s digit of your answer. Also remember {p_prev} now becomes {p_prev - 1}.");
                                }
                            }

                            step += 1;
                            div *= 10;
                            max_digit--;
                        }

                    }
                    if (result.Entities[2].Type == NUM)
                        await context.PostAsync("*Hope you now understand the method correctly! \n We have shown you how to calculate for your first 2 nos. Now you know how to subtract 2 nos. Do the rest yourself. All the best!*");
                    else
                        await context.PostAsync("*Hope you now understand the method. Don't hesitate to ask more queries, I'm there for you whenever you need :) *");
                }
            }
            else if (add == 0 && multi != 0 && divi == 0 && subt == 0)
            {
                await context.PostAsync("**Remember**, I wil help you reach till the answer to your problem but will *not* give you the final answer. work the steps out on a paper and be patient. **Happy solving **:) ");
                if (result.TryFindEntity(MUL, out title))
                {
                    string a1 = result.Entities[0].Entity;
                    string b1 = result.Entities[1].Entity;
                    string c1 = result.Entities[2].Entity;

                    int max_digit = b1.Length;
                    int min_digit;
                    int a = int.Parse(a1);
                    int b = int.Parse(b1);
                    int fix = 1, div;
                    int p, q, carry = 0, step = 1, c = 1, d = 1, m = 0;
                    while (max_digit != 0)
                    {
                        div = 1;
                        min_digit = a1.Length;
                        await context.PostAsync($"**STEP {step}**");
                        while (min_digit != 0)
                        {
                            p = (a / div) % 10;
                            q = (b / fix) % 10;
                            m = p * q;
                            carry = ((p * q + carry) / 10) % 10;
                            c = ((b / fix) % 10) * a;
                            await context.PostAsync($"Multiply {fix}'s digit of {b} with {div}'s digit of {a} ");
                            if (min_digit > 1)
                            {
                                await context.PostAsync($"Number obtained is {m}, so  carry generated is {carry} this will be added when you multiply next digits ");
                            }
                            div *= 10;
                            min_digit--;
                        }
                        if (fix > 1)
                        {
                            await context.PostAsync($"Add {c}*{fix} to previously obtained result {d}");
                        }
                        fix *= 10;
                        max_digit--;
                        step += 1;
                        d = c;
                    }
                    if (result.Entities[2].Type == NUM)
                        await context.PostAsync("*Hope you now understand the method correctly! \n We have shown you how to calculate for your first 2 nos. Now you know how to multiply 2 nos, you can repeat the process by multiplying the next number to the answer of the previous multiply.I would insist you to do the rest yourself. All the best!*");
                    else
                        await context.PostAsync("*Hope you now understand the method. Don't hesitate to ask more queries, I'm there for you whenever you need :) *");
                }
            }
            else if (add == 0 && multi == 0 && divi != 0 && subt == 0)
            {
                await context.PostAsync("**Remember**, I wil help you reach till the answer to your problem but will *not* give you the final answer. work the steps out on a paper and be patient. **Happy solving **:) ");
                if (result.TryFindEntity(DIV, out title))
                {
                    string a1 = result.Entities[0].Entity;
                    string b1 = result.Entities[1].Entity;
                    int x = b1.Length;
                    int a = int.Parse(a1);
                    int b = int.Parse(b1);
                    int e;
                    int y, c, step = 1;
                    if (b == 0)
                    {
                        await context.PostAsync(" Division by 0 is not allowed ");
                    }
                    while (b <= a)
                    {
                        await context.PostAsync($"**STEP {step}**");

                        int d = (a.ToString()).Length;
                        y = a / power(d - x);
                        if (b <= y)
                        {
                            c = y / b;
                            await context.PostAsync($"Since {y} is greater than {b} , We will divide {y} by {b} , so the largest multiple of {b} which is less than {y} is {c * b}. so the {step} 's digit of your quotient is {c}");
                            a = (a - (c * b) * power(d - x));
                            await context.PostAsync($"Now we subtract {c * b} from  {y} and obtain {y - (c * b)}. after this we bring down the next digit from the divident and obtain {a} ");
                        }
                        else
                        {
                            e = y;
                            y = a / power(d - x - 1);
                            c = y / b;
                            await context.PostAsync($"Since {e} is less than {b} , and {y} is greater than {b}  we will consider {y} and divide it by {b} , So the largest multiple of {b} which is less than {y} is {c * b} .so, the {step} 's digit of your quotient is {c}");
                            a = (a - (c * b) * power(d - x - 1));
                            await context.PostAsync($"Now we subtract {c * b} from  {y} and obtain {y - (c * b)}. after this we bring down the next digit from the divident and obtain {a} ");

                        }
                        step += 1;
                    }
                    await context.PostAsync("Now since there are no more digits left in the divident to bring down, and the number obtaind has become less than the divisor {b} , you can no longer proceed and hence you obtain your remainder ");
                    if (result.Entities[2].Type == NUM)
                        await context.PostAsync("*Hope you now understand the method correctly! \n We have shown you how to calculate for your first 2 nos. Now you know how to divide 2 nos. Do the rest yourself. All the best!*");
                    else
                        await context.PostAsync("*Hope you now understand the method. Don't hesitate to ask more queries, I'm there for you whenever you need :) *");

                }
            }
            else
            {
                if (divi != 0)
                {
                    await context.PostAsync($"**Step {step1}**");
                    await context.PostAsync("According to the BO**D**MAS rule, proceed with division of numbers.");
                    await context.PostAsync("*If you want to learn how to divide 2 nos. then type a problem statement accordingly*");
                    step1++;
                }
                if (multi != 0)
                {
                    await context.PostAsync($"**Step {step1}**");
                    await context.PostAsync("According to the BOD**M**AS rule, proceed with multiplication of numbers. ");
                    await context.PostAsync("*If you want to learn how to multiply 2 nos. then type a problem statement accordingly*");
                    step1++;
                }
                if (add != 0)
                {
                    await context.PostAsync($"**Step {step1}**");
                    await context.PostAsync("According to the BODM**A**S rule, proceed with addition of numbers. ");
                    await context.PostAsync("*If you want to learn how to add 2 nos. then type a problem statement accordingly*");
                    step1++;
                }
                if (subt != 0)
                {
                    await context.PostAsync($"**Step {step1}**");
                    await context.PostAsync("According to the BODMA**S** rule, proceed with subtraction of numbers. ");
                    await context.PostAsync("*If you want to learn how to subtract 2 nos. then type a problem statement accordingly*");
                }
            }

            context.Wait(MessageReceived);
        }


        [LuisIntent("check")]
        public async Task chk(IDialogContext context, LuisResult result)
        {
            EntityRecommendation title;

            if (result.TryFindEntity(ADD, out title))
            {
                string a1 = result.Entities[0].Entity;
                string b1 = result.Entities[1].Entity;
                string c1 = result.Entities[2].Entity;
                int a = int.Parse(a1);
                int b = int.Parse(b1);
                int c = int.Parse(c1);
                int d = a + b;
               
                {
                    if (d == c)
                        await context.PostAsync("You are right!");
                    else
                        await context.PostAsync("oops! try again");
                }

            }

            else if (result.TryFindEntity(SUB, out title))
            {
                string a1 = result.Entities[0].Entity;
                string b1 = result.Entities[1].Entity;
                string c1 = result.Entities[2].Entity;
                int a = int.Parse(a1);
                int b = int.Parse(b1);
                int c = int.Parse(c1);
                int d;
                if (title.Entity == "-")
                    d = a - b;
                else
                    d = b - a;
               
                {
                    if (d == c)
                        await context.PostAsync("You are right!");
                    else
                        await context.PostAsync("oops! try again");
                }
            }

            else if (result.TryFindEntity(MUL, out title))
            {
                string a1 = result.Entities[0].Entity;
                string b1 = result.Entities[1].Entity;
                string c1 = result.Entities[2].Entity;
                int a = int.Parse(a1);
                int b = int.Parse(b1);
                int c = int.Parse(c1);
                int d = a * b;
               
                
                {
                    if (d == c)
                        await context.PostAsync("You are right!");
                    else
                        await context.PostAsync("oops! try again");
                }
            }

            else if (result.TryFindEntity(DIV, out title))
            {
                string a1 = result.Entities[0].Entity;
                string b1 = result.Entities[1].Entity;
                string c1 = result.Entities[2].Entity;
                int a = int.Parse(a1);
                int b = int.Parse(b1);
                int c = int.Parse(c1);
                int d = a / b;
                
                {
                    if (d == c)
                        await context.PostAsync("You are right!");
                    else
                        await context.PostAsync("oops! try again");
                }

            }
            else
                await context.PostAsync("Query Incompatible. Try another query");

            context.Wait(MessageReceived);

        }

    }

}