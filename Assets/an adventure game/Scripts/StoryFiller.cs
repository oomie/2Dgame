public static class StoryFiller
{
    public static StoryNode FillStory()
    {
        var root = CreateNode(
            "The Annual Tournament is about to start. You face the maze in front of you, nervously waiting for the game to begin." +
            "The game starts, and the maze reveals two starting routes. Where do you go?",
            new[] {
            "Turn left", // -> node1
            "Turn right"}); // -> node 2

        //left --> node 3, node 2
        var node1 = CreateNode(
            "You encounter a dead end.. " +
            "You notice a twig sticking out from one of the bushes.",
            new[] {
            "Pull the twig",
            "Go to the right path instead",});

        //right  --> node 4,1 (right--> node 4 , left --> node 1 )
        var node2 = CreateNode(
            "You keep walking along the path when you reach a fork in the road." +
            "Which path do you go on?",
            new[] {
            "Left",
            "Right"});

        // pull the twig --> node 6
        var node3 = CreateNode(
           "You pull the twig, and hear something moving behind you." +
           "You turn around and notice an undergound path has opened up...",
           new[] {
            "go to where it leads",
            "follow the path"}); //both lead to the same node

        //straight & right --> node 5
        var node4 = CreateNode(
           "As you walk along the path, you notice a something shiny on the ground." +
           "It looks like a key..",
           new[] {
            "grab it",
            "keep it"}); //same node

        // key cont'd :chest 1 --> node 9  chest 2 --> node 10
        var node5 = CreateNode(
           "You continue walking along the maze when you find a clearing. There are two chests, which one will you try to open with your key?",
          new[] {
            "Chest 1",
            "Chest 2"});

        // pull the twig cont'd  --> node 7, 8
        var node6 = CreateNode(
            "You enter what seems to be an underground library. You notice a desk in the corner.. " +
            "The desk drawers look half open.",
            new[] {
            "Explore the drawers", // --> node 7
            "Continue looking around the room"}); // --> node 8

        // explore the drawers 
        var node7 = CreateNode(
          "You look through the drawers and find a key.",
          new[] {
            "grab the key",
            "take a look at the key"}); // --> node 11

        //look around the room
        var node8 = CreateNode(
           "You look around, and see something shiny coming from one of the drawers.",
           new[] {
            "check the drawers",
            "look through the drawers"}); //--> node7

        //chest 1 --> node 10
        var node9 = CreateNode(
          "You put the key into the keyhole and turn it. It doesnt open. :(",
          new[] {
            "Try the other chest",
            "check out the second chest"}); // --> node 10

        //chest 2 --> node 13
        var node10 = CreateNode(
          "You put the key into the keyhole and turn it. It works! You open the chest to find a map of the maze!.",
          new[] {
            "follow the map to the exit!",
            "go to the exit!!"}); //both n13

        //pull the book to reveal the hidden door
        var node11 = CreateNode(
          "You look around for something to unlock with." +
           "you notice one of the books on the shelf is sticking out..",
          new[] {
            "pull the book out",
            "push the book in"}); // --> node 12

        //unlock the door 
        var node12 = CreateNode(
          "The bookshelf moves to reveal a hidden door! You pull the handle, but it's locked." +
          "",
          new[] {
            "unlock the door with your key",
            "try unlocking the door.."}); // --> node 13

        //WIN screen (both)
        var node13 = CreateNode(
          "You made it out ! YOU WIN!",
          new[] {
            "You made it out ! YOU WIN!"});

        root.NextNode[0] = node1;
        root.NextNode[1] = node2;

        node1.NextNode[0] = node3;
        node1.NextNode[1] = node2;

        node2.NextNode[0] = node4;
        node2.NextNode[1] = node1;

        node3.NextNode[0] = node6;
        node3.NextNode[1] = node6;

        node4.NextNode[0] = node5;
        node4.NextNode[1] = node5;

        node5.NextNode[0] = node9;
        node5.NextNode[1] = node10;

        node6.NextNode[0] = node7;
        node6.NextNode[1] = node8;

        node7.NextNode[0] = node11;
        node7.NextNode[1] = node11;

        node8.NextNode[0] = node7;
        node8.NextNode[1] = node7;

        node9.NextNode[0] = node10;
        node9.NextNode[1] = node10;

        node10.NextNode[0] = node13; //win
        node10.NextNode[1] = node13;

        node13.NextNode[0] = root; //win 1

        node11.NextNode[0] = node12;
        node11.NextNode[1] = node12;

        node12.NextNode[0] = node13; 
        node12.NextNode[1] = node13; //win 2

        node13.IsFinal = true;

        return root;
    }

    private static StoryNode CreateNode(string history, string[] options)
    {
        var node = new StoryNode
        {
            History = history,
            Answers = options,
            NextNode = new StoryNode[options.Length]
        };
        return node;
    }
}
