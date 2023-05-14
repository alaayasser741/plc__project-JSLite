
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF            =  0, // (EOF)
        SYMBOL_ERROR          =  1, // (Error)
        SYMBOL_WHITESPACE     =  2, // Whitespace
        SYMBOL_MINUS          =  3, // '-'
        SYMBOL_MINUSMINUS     =  4, // '--'
        SYMBOL_EXCLAMEQ       =  5, // '!='
        SYMBOL_PERCENT        =  6, // '%'
        SYMBOL_LPAREN         =  7, // '('
        SYMBOL_RPAREN         =  8, // ')'
        SYMBOL_TIMES          =  9, // '*'
        SYMBOL_TIMESTIMES     = 10, // '**'
        SYMBOL_COMMA          = 11, // ','
        SYMBOL_DIV            = 12, // '/'
        SYMBOL_COLON          = 13, // ':'
        SYMBOL_SEMI           = 14, // ';'
        SYMBOL_QUESTION       = 15, // '?'
        SYMBOL_LBRACKET       = 16, // '['
        SYMBOL_RBRACKET       = 17, // ']'
        SYMBOL_LBRACE         = 18, // '{'
        SYMBOL_RBRACE         = 19, // '}'
        SYMBOL_PLUS           = 20, // '+'
        SYMBOL_PLUSPLUS       = 21, // '++'
        SYMBOL_LT             = 22, // '<'
        SYMBOL_EQ             = 23, // '='
        SYMBOL_EQEQ           = 24, // '=='
        SYMBOL_GT             = 25, // '>'
        SYMBOL_CASE           = 26, // case
        SYMBOL_DIGIT          = 27, // Digit
        SYMBOL_DOUBLE         = 28, // double
        SYMBOL_ELSE           = 29, // else
        SYMBOL_END            = 30, // End
        SYMBOL_FLOAT          = 31, // float
        SYMBOL_FOR            = 32, // for
        SYMBOL_ID             = 33, // Id
        SYMBOL_IF             = 34, // if
        SYMBOL_INT            = 35, // int
        SYMBOL_START          = 36, // Start
        SYMBOL_STRING         = 37, // string
        SYMBOL_SWITCH         = 38, // switch
        SYMBOL_ARRAY          = 39, // <array>
        SYMBOL_ASSIGNMENT     = 40, // <assignment>
        SYMBOL_CASE2          = 41, // <case>
        SYMBOL_CASEMINUSLIST  = 42, // <case-list>
        SYMBOL_CONCEPT        = 43, // <concept>
        SYMBOL_CONDITION      = 44, // <condition>
        SYMBOL_DATAMINUSTYPE  = 45, // <data-type>
        SYMBOL_DIGIT2         = 46, // <digit>
        SYMBOL_EXPONENT       = 47, // <exponent>
        SYMBOL_EXPR           = 48, // <expr>
        SYMBOL_FACTOR         = 49, // <factor>
        SYMBOL_FOR2           = 50, // <for>
        SYMBOL_FUNCTION       = 51, // <function>
        SYMBOL_ID2            = 52, // <id>
        SYMBOL_IF2            = 53, // <if>
        SYMBOL_OP             = 54, // <op>
        SYMBOL_PARAM          = 55, // <param>
        SYMBOL_PARAMMINUSLIST = 56, // <param-list>
        SYMBOL_PROGRAM        = 57, // <program>
        SYMBOL_STATEMENT      = 58, // <statement>
        SYMBOL_STEP           = 59, // <step>
        SYMBOL_SWITCH2        = 60, // <switch>
        SYMBOL_TERM           = 61, // <term>
        SYMBOL_TERNARY        = 62  // <ternary>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                             =  0, // <program> ::= Start <statement> End
        RULE_STATEMENT                                     =  1, // <statement> ::= <concept>
        RULE_STATEMENT2                                    =  2, // <statement> ::= <concept> <statement>
        RULE_CONCEPT                                       =  3, // <concept> ::= <assignment>
        RULE_CONCEPT2                                      =  4, // <concept> ::= <if>
        RULE_CONCEPT3                                      =  5, // <concept> ::= <for>
        RULE_CONCEPT4                                      =  6, // <concept> ::= <switch>
        RULE_CONCEPT5                                      =  7, // <concept> ::= <ternary>
        RULE_CONCEPT6                                      =  8, // <concept> ::= <function>
        RULE_CONCEPT7                                      =  9, // <concept> ::= <array>
        RULE_ASSIGNMENT_EQ                                 = 10, // <assignment> ::= <id> '=' <expr>
        RULE_ID_ID                                         = 11, // <id> ::= Id
        RULE_EXPR_PLUS                                     = 12, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                    = 13, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                          = 14, // <expr> ::= <term>
        RULE_TERM_TIMES                                    = 15, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                      = 16, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                  = 17, // <term> ::= <term> '%' <factor>
        RULE_TERM                                          = 18, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                             = 19, // <factor> ::= <factor> '**' <exponent>
        RULE_FACTOR                                        = 20, // <factor> ::= <exponent>
        RULE_EXPONENT_LPAREN_RPAREN                        = 21, // <exponent> ::= '(' <expr> ')'
        RULE_EXPONENT                                      = 22, // <exponent> ::= <id>
        RULE_EXPONENT2                                     = 23, // <exponent> ::= <digit>
        RULE_DIGIT_DIGIT                                   = 24, // <digit> ::= Digit
        RULE_ARRAY_LBRACKET_RBRACKET                       = 25, // <array> ::= <id> '[' <expr> ']'
        RULE_IF_IF_LPAREN_RPAREN_LBRACE_RBRACE             = 26, // <if> ::= if '(' <condition> ')' '{' <statement> '}'
        RULE_IF_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE        = 27, // <if> ::= if '(' <condition> ')' '{' <statement> '}' else <statement>
        RULE_CONDITION                                     = 28, // <condition> ::= <expr> <op> <expr>
        RULE_OP_LT                                         = 29, // <op> ::= '<'
        RULE_OP_GT                                         = 30, // <op> ::= '>'
        RULE_OP_EQEQ                                       = 31, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                   = 32, // <op> ::= '!='
        RULE_FOR_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE = 33, // <for> ::= for '(' <data-type> <assignment> ';' <condition> ';' <step> ')' '{' <statement> '}'
        RULE_DATATYPE_INT                                  = 34, // <data-type> ::= int
        RULE_DATATYPE_FLOAT                                = 35, // <data-type> ::= float
        RULE_DATATYPE_DOUBLE                               = 36, // <data-type> ::= double
        RULE_DATATYPE_STRING                               = 37, // <data-type> ::= string
        RULE_STEP_MINUSMINUS                               = 38, // <step> ::= '--' <id>
        RULE_STEP_MINUSMINUS2                              = 39, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS                                 = 40, // <step> ::= '++' <id>
        RULE_STEP_PLUSPLUS2                                = 41, // <step> ::= <id> '++'
        RULE_STEP                                          = 42, // <step> ::= <assignment>
        RULE_SWITCH_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE     = 43, // <switch> ::= switch '(' <expr> ')' '{' <case-list> '}'
        RULE_CASELIST                                      = 44, // <case-list> ::= <case>
        RULE_CASELIST2                                     = 45, // <case-list> ::= <case> <case-list>
        RULE_CASE_CASE_COLON                               = 46, // <case> ::= case <expr> ':' <statement>
        RULE_TERNARY_QUESTION                              = 47, // <ternary> ::= <expr> '?' <statement>
        RULE_TERNARY_COLON                                 = 48, // <ternary> ::= <expr> ':' <statement>
        RULE_TERNARY                                       = 49, // <ternary> ::= <expr>
        RULE_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE          = 50, // <function> ::= <id> '(' <param-list> ')' '{' <statement> '}'
        RULE_PARAMLIST                                     = 51, // <param-list> ::= <param>
        RULE_PARAMLIST_COMMA                               = 52, // <param-list> ::= <param> ',' <param-list>
        RULE_PARAM                                         = 53  // <param> ::= <data-type> <id>
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAY :
                //<array>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE2 :
                //<case>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASEMINUSLIST :
                //<case-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATAMINUSTYPE :
                //<data-type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPONENT :
                //<exponent>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR2 :
                //<for>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //<function>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF2 :
                //<if>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAM :
                //<param>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMMINUSLIST :
                //<param-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH2 :
                //<switch>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERNARY :
                //<ternary>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= Start <statement> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <concept> <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <for>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <switch>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <ternary>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <function>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT7 :
                //<concept> ::= <array>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_EQ :
                //<assignment> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exponent>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exponent>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPONENT_LPAREN_RPAREN :
                //<exponent> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPONENT :
                //<exponent> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPONENT2 :
                //<exponent> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAY_LBRACKET_RBRACKET :
                //<array> ::= <id> '[' <expr> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<if> ::= if '(' <condition> ')' '{' <statement> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE :
                //<if> ::= if '(' <condition> ')' '{' <statement> '}' else <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<condition> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<for> ::= for '(' <data-type> <assignment> ';' <condition> ';' <step> ')' '{' <statement> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_INT :
                //<data-type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_FLOAT :
                //<data-type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_DOUBLE :
                //<data-type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_STRING :
                //<data-type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE :
                //<switch> ::= switch '(' <expr> ')' '{' <case-list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST :
                //<case-list> ::= <case>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST2 :
                //<case-list> ::= <case> <case-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_CASE_COLON :
                //<case> ::= case <expr> ':' <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERNARY_QUESTION :
                //<ternary> ::= <expr> '?' <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERNARY_COLON :
                //<ternary> ::= <expr> ':' <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERNARY :
                //<ternary> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE :
                //<function> ::= <id> '(' <param-list> ')' '{' <statement> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMLIST :
                //<param-list> ::= <param>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMLIST_COMMA :
                //<param-list> ::= <param> ',' <param-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAM :
                //<param> ::= <data-type> <id>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
