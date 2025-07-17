using Zork1.Library;
using Zork1.Library.Extensions;

namespace Zork1.Library.ActionRoutines;

//<ROUTINE V-OPEN("AUX" F STR)
//	 <COND(<AND<FSET?, PRSO, CONTBIT>
//		     <NOT<EQUAL? <GETP , PRSO , P? CAPACITY> 0>>>
//		<COND (<FSET? , PRSO , OPENBIT>
//		       <TELL "It is already open." CR>)

//              (T
//               <FSET, PRSO, OPENBIT>
//		       <FSET ,PRSO ,TOUCHBIT>
//		       <COND(<OR<NOT<FIRST?, PRSO>> <FSET? , PRSO , TRANSBIT>>
//			      <TELL "Opened." CR>)

//                 (<AND<SET F<FIRST? , PRSO>>
//				   <NOT<NEXT? .F>>
//				   <NOT<FSET? .F, TOUCHBIT>>
//				   <SET STR <GETP.F , P? FDESC>>>
//			      <TELL "The " D , PRSO " opens." CR>
//			      <TELL.STR CR>)

//                 (T
//                  <TELL "Opening the " D, PRSO " reveals ">
//			      <PRINT-CONTENTS ,PRSO>
//			      <TELL "." CR>)>)>)
//	       (<FSET? ,PRSO ,DOORBIT>
//		<COND(<FSET? , PRSO , OPENBIT>
//		       <TELL "It is already open." CR>)

//              (T
//               <TELL "The " D, PRSO " opens." CR>
//		       <FSET ,PRSO ,OPENBIT>)>)
//	       (T
//        <TELL
//"You must tell me how to do that to a " D, PRSO "." CR>)>>
public class OpenWith : Unlock
{
    public OpenWith()
    {
        Verbs = ["open"];
        Prepositions = ["with"];
    }
}

public class Open : Routine
{
    public Open()
    {
        Verbs = ["open", "uncover", "undo", "unwrap"];
        Requires = [X.Noun];
        ImplicitMessage = (o) => $"(first opening {o.DName})";
    }

    public override bool Handler(Object obj, Object _ = null)
    {
        if (!obj.Openable)
        {
            return Fail($"{obj.TheyreOrThats} not something you can open.");
        }
        else if (obj.Locked)
        {
            string seems = obj.PluralName ? "seem" : "seems";
            return Fail($"{obj.DName} {seems} to be locked.");
        }
        else if (obj.Open)
        {
            return Fail($"It is already open.");
        }
        else
        {
            obj.Open = true;
            obj.Touched = true;

            if (obj is Container container && container.Children.Count > 0)
            {
                return Success($"Opening {obj.DName} reveals {Display.List(container.Children, false)}.");
            }
            
            return Print($"You open {obj.DName}.");
        }
    }
}
