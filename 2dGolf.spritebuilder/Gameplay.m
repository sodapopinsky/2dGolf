//
//  Gameplay.m
//  2dGolf
//
//  Created by Nick Spitale on 9/13/14.
//  Copyright (c) 2014 Apportable. All rights reserved.
//

#import "Gameplay.h"

@implementation Gameplay{
    CCPhysicsNode *_physicsNode;
     CCNode *_golfBall;
}

// is called when CCB file has completed loading
- (void)didLoadFromCCB {
    // tell this scene to accept touches
    self.userInteractionEnabled = TRUE;
}

// called on every touch in this scene
- (void)touchBegan:(UITouch *)touch withEvent:(UIEvent *)event {
    [self launchPenguin];
    self.position = ccp(0, 0);
    CCActionFollow *follow = [CCActionFollow actionWithTarget:_golfBall worldBoundary:self.boundingBox];
    [self runAction:follow];
}

- (void)launchPenguin {
    /*
    // loads the Penguin.ccb we have set up in Spritebuilder
    CCNode* penguin = [CCBReader load:@"GolfBall"];
    // position the penguin at the bowl of the catapult
    penguin.position = ccpAdd(_golfBall.position, ccp(16, 50));
    
    // add the penguin to the physicsNode of this scene (because it has physics enabled)
    [_physicsNode addChild:penguin];
    */
    // manually create & apply a force to launch the penguin
    CGPoint launchDirection = ccp(.5, 1);
    CGPoint force = ccpMult(launchDirection, 5000);
    [_golfBall.physicsBody applyForce:force];
}
@end
