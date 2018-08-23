open System
open System.IO
open System.Drawing

let words = File.ReadAllLines("words.txt") 
let stopWords = File.ReadAllLines("stop-words.txt")

let getLetterNumber letter = 
    let letters = ['a' .. 'z']
    letters
    |> List.toArray
    |> Array.findIndex (fun x -> x = letter)
    |> (+) 1

let getWordValue (word: string) = 
    let letters = [for letter in word -> letter]
    letters
    |> List.map (fun letter -> getLetterNumber letter)
    |> List.sum


let wordsWith100 = 
    let isAStopWord word = stopWords |> Array.contains word
    words
    |> Array.filter (fun word -> getWordValue word = 100) 
    |> Array.filter (fun word -> not (isAStopWord word)) // Remove all stop words.
    // 2981 words


let randomWordSample count wordlist= 
    let rnd = new Random()
    wordlist
    |> Seq.sortBy (fun _ -> rnd.Next())
    |> Seq.take count

randomWordSample 10 wordsWith100 |> Seq.toArray