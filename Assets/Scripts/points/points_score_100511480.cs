using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

class points_score_100511480
{
    private int _total_score;
    private int _temp_points;
    private int _drifting_multiplier;
    private int _MAX_MULTIPLIER;
    private int _MIN_MULTIPLIER;
    private int _FINAL_SCORE;

    //constructors
    public points_score_100511480()
    {
        _total_score = 0;
        _temp_points = 0;
        _drifting_multiplier = 1;
        _MAX_MULTIPLIER = 10;
        _MIN_MULTIPLIER = 1;
        _FINAL_SCORE = 0;
    }
    public points_score_100511480(int max_multiplier, int min_multiplier)
    {
        _total_score = 0;
        _temp_points = 0;
        _drifting_multiplier = 1;
        _MAX_MULTIPLIER = max_multiplier;
        _MIN_MULTIPLIER = min_multiplier;
        _FINAL_SCORE = 0;
    }
    public points_score_100511480(int max_multiplier, int min_multiplier,int drifting_m)
    {
        _total_score = 0;
        _temp_points = 0;
        _drifting_multiplier = drifting_m;
        _MAX_MULTIPLIER = max_multiplier;
        _MIN_MULTIPLIER = min_multiplier;
        _FINAL_SCORE = 0;
    }
    public points_score_100511480(int max_multiplier, int min_multiplier, int drifting_m, int total_score)
    {
        _total_score = total_score;
        _temp_points = 0;
        _drifting_multiplier = drifting_m;
        _MAX_MULTIPLIER = max_multiplier;
        _MIN_MULTIPLIER = min_multiplier;
        _FINAL_SCORE = 0;
    }
    public points_score_100511480(points_score_100511480 p)
    {
        copy(p);
    }

    // GETS/SETS and incrementing functions for the variables 
    public int Get_total_score()
    {
        return _total_score;
    }
    public void Set_total_score(int score)
    {
        _total_score = score;
    }
    public int Get_temp_points()
    {
        return _temp_points;
    }
    public void Set_temp_points(int points)
    {
        _temp_points = points;
    }
    public int Get_drifting_multiplier()
    {
        return _drifting_multiplier;
    }
    public void Set_drifting_multiplier(int multiplier)
    {
        _drifting_multiplier = multiplier;
    }

    public int GET_MAX_MULTIPLIER()
    {
        return _MAX_MULTIPLIER;
    }
    public void SET_MAX_MULTIPLIER(int m)
    {
        _MAX_MULTIPLIER = m;
    }

    public int GET_MIN_MULTIPLIER()
    {
        return _MIN_MULTIPLIER;
    }
    public void SET_MIN_MULTIPLIER(int m)
    {
        _MIN_MULTIPLIER = m;
    }

    public int GET_FINAL_SCORE()
    {
        return _FINAL_SCORE;
    }
    public void SET_FINAL_SCORE(int f)//For use in copy constructors only
    {
        _FINAL_SCORE = f;
    }
    
    //methods
    public virtual void copy(points_score_100511480 p)
    {
        _total_score = p.Get_total_score();
        _temp_points = p.Get_temp_points();
        _drifting_multiplier = p.Get_drifting_multiplier();
        _MAX_MULTIPLIER = p.GET_MAX_MULTIPLIER();
        _MIN_MULTIPLIER = p.GET_MIN_MULTIPLIER();
        _FINAL_SCORE = p.GET_FINAL_SCORE();
    }

    public void Increment_drifting_multiplier(int i)//adds to multiplier
    {
        if (_drifting_multiplier + i > _MAX_MULTIPLIER)
        {
            _drifting_multiplier = _MAX_MULTIPLIER;
        }
        else
        {
            _drifting_multiplier = _drifting_multiplier + i;
        }
    }
    public void Decrement_drifting_multiplier(int i)//decreases multiplier
    {
        if (_drifting_multiplier - i < _MIN_MULTIPLIER)
        {
            _drifting_multiplier = _MIN_MULTIPLIER;
        }
        else
        {
            _drifting_multiplier = _drifting_multiplier - i;
        }
    }

    public void ADD_TO_TEMP_SCORE(int to_add)//Adds points * multiplier to temp_points.
    {
        _temp_points = _temp_points + to_add;
    }
    public void BANK_POINTS()//Adds temp points to total score
    {
        Set_total_score(_total_score + (int)((float)_temp_points * (float)_drifting_multiplier));
        Set_temp_points(0);
    }

    public virtual void CALCULATE_FINAL_SCORE()//Gets overloaded for the race modes.
    {
        _FINAL_SCORE = _total_score; //**************************************** alter when we figure out what end-of-game multiplers will be added
    }
}

// ******************** Child classes: ********************

// ********** Time Trial **********
class time_trial_score_100511480 : points_score_100511480
{
    //points affect time reduction at end of race
    private float _time;
    
    //constructors
    public time_trial_score_100511480() : base()
    {
        _time = 0;
    }
    public time_trial_score_100511480(float time): base()
    {
        _time = time;
    }
    public time_trial_score_100511480(float time, int max_multiplier, int min_multiplier) : base(max_multiplier, min_multiplier)
    {
        _time = time;
    }
    public time_trial_score_100511480(float time, int max_multiplier, int min_multiplier, int drifting_m) : base(max_multiplier, min_multiplier,drifting_m)
    {
        _time = time;
    }
    public time_trial_score_100511480(float time, int max_multiplier, int min_multiplier,int drifting_m, int total_score) : base(max_multiplier, min_multiplier, total_score, drifting_m)
    {
        _time = time;
    }
    public time_trial_score_100511480(time_trial_score_100511480 p):base(p)
    {
        copy(p);
    }

    // gets and sets

    public float Get_time()
    {
        return _time;
    }
    public void Set_time(int t)
    {
        _time = t;
    }
    //functions/methods

    public void copy(time_trial_score_100511480 p)
    {
        Set_total_score(p.Get_total_score());
        Set_temp_points(p.Get_temp_points());
        Set_drifting_multiplier(p.Get_drifting_multiplier());
        SET_MAX_MULTIPLIER(p.GET_MAX_MULTIPLIER());
        SET_MIN_MULTIPLIER(p.GET_MIN_MULTIPLIER());
        SET_FINAL_SCORE(p.GET_FINAL_SCORE());
        _time = p.Get_time();
    }

    public override void CALCULATE_FINAL_SCORE()
    {
        //A calculation that uses the time to give a bonus to the score. Smaller time = more bonus.
        SET_FINAL_SCORE( Get_total_score()); //**************************************** alter when we figure out what end-of-game multiplers will be added
    }

}

// ********** Againtst The Clock **********
class beat_the_clock_score_100511480 : points_score_100511480
{
    //points given based on time left
    private float _time_remaining;
    private float _time_score_multiplier;

    //constructors
    public beat_the_clock_score_100511480() : base()
    {
        _time_remaining = 0;
        _time_score_multiplier = 1;
    }
    public beat_the_clock_score_100511480(float time_remaining, float time_score_multiplier) : base()
    {
        _time_remaining = time_remaining;
        _time_score_multiplier = time_score_multiplier;
    }
    public beat_the_clock_score_100511480(float time_remaining, float time_score_multiplier, int max_multiplier, int min_multiplier) : base(max_multiplier, min_multiplier)
    {
        _time_remaining = time_remaining;
        _time_score_multiplier = time_score_multiplier;
    }
    public beat_the_clock_score_100511480(float time_remaining, float time_score_multiplier, int max_multiplier, int min_multiplier, int drifting_m) : base( max_multiplier, min_multiplier, drifting_m)
    {
        _time_remaining = time_remaining;
        _time_score_multiplier = time_score_multiplier;
    }
    public beat_the_clock_score_100511480(float time_remaining, float time_score_multiplier, int max_multiplier, int min_multiplier, int drifting_m, int total_score) : base(  max_multiplier, min_multiplier, drifting_m, total_score)
    {
        _time_remaining = time_remaining;
        _time_score_multiplier = time_score_multiplier;
    }
    public beat_the_clock_score_100511480(beat_the_clock_score_100511480 p): base(p)
    {
        copy(p);
    }

    //Gets/sets
    public float Get_time_remaining()
    {
        return _time_remaining;
    }
    public void Set_time_remaining(float t)
    {
        _time_remaining = t;
    }
    public float Get_time_score_multiplier()
    {
        return _time_score_multiplier;
    }
    public void Set_time_score_multiplier(float m)
    {
        _time_score_multiplier = m;
    }

    //methods/functions
    public void copy(beat_the_clock_score_100511480 p)
    {
        Set_total_score(p.Get_total_score());
        Set_temp_points(p.Get_temp_points());
        Set_drifting_multiplier(p.Get_drifting_multiplier());
        SET_MAX_MULTIPLIER(p.GET_MAX_MULTIPLIER());
        SET_MIN_MULTIPLIER(p.GET_MIN_MULTIPLIER());
        SET_FINAL_SCORE(p.GET_FINAL_SCORE());
        _time_remaining = p.Get_time_remaining();
        _time_score_multiplier = p.Get_time_score_multiplier();
    }

    public override void CALCULATE_FINAL_SCORE()
    {
        SET_FINAL_SCORE(Get_total_score() + (int)(_time_remaining * _time_score_multiplier)); //*************************** subjct to change from other bonuses
    }

}

// ********** Race **********
class race_score_100511480 : points_score_100511480
{
    private float _race_dificulty_multiplier;
  

    public race_score_100511480(): base()
    {
        _race_dificulty_multiplier = 1;
    }

    public race_score_100511480(int max_multiplier, int min_multiplier,float dificulty_multiplier) : base(max_multiplier, min_multiplier)
    {
        _race_dificulty_multiplier = dificulty_multiplier;
    }
    public race_score_100511480(int max_multiplier, int min_multiplier, float dificulty_multiplier, int drifting_m) : base(max_multiplier, min_multiplier, drifting_m)
    {
        _race_dificulty_multiplier = dificulty_multiplier;
    }

    public race_score_100511480(int max_multiplier, int min_multiplier, float dificulty_multiplier, int drifting_m, int total_score) : base( max_multiplier, min_multiplier, drifting_m, total_score)
    {
        _race_dificulty_multiplier = dificulty_multiplier;
    }
    public race_score_100511480(race_score_100511480 p) : base(p)
    {
        copy(p);
    }

    //gets/sets
    public float Get_dificulty_multipier()
    {
        return _race_dificulty_multiplier;
    }
    public void Set_dificulty_multiplier(float m)
    {
        _race_dificulty_multiplier = m;
    }


    //methods/functions
    public void copy(race_score_100511480 p)
    {
        Set_total_score(p.Get_total_score());
        Set_temp_points(p.Get_temp_points());
        Set_drifting_multiplier(p.Get_drifting_multiplier());
        SET_MAX_MULTIPLIER(p.GET_MAX_MULTIPLIER());
        SET_MIN_MULTIPLIER(p.GET_MIN_MULTIPLIER());
        SET_FINAL_SCORE(p.GET_FINAL_SCORE());
        _race_dificulty_multiplier = p.Get_dificulty_multipier();
    }

    public void CALCULATE_END_OF_RACE_SCORE(int place_bonus)/// TO BE CALLED AT THE END OF EACH RACE.
    {
        Set_total_score( place_bonus + Get_total_score());
    }
    public override void CALCULATE_FINAL_SCORE()///CALL AFTER AND ONLY AFTER CALCULATE_END_OF_RACE_SCORE.
    {
        SET_FINAL_SCORE((int)((float)Get_total_score() * Get_dificulty_multipier()));// *************************** subjct to change from other bonuses
    }
    
}
