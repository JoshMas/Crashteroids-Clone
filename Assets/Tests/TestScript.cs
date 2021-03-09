using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    private GameManager manager;
    
    [SetUp]
    public void SetUp()
    {
        GameObject game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        manager = game.GetComponent<GameManager>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(manager.gameObject);
    }

    [UnityTest]
    public IEnumerator AsteroidMoveDown()
    {

        //Wait one frame for the asteroid list to be instantiated
        //yield return null;
        GameObject testAsteroid = manager.SpawnAsteroid();
        float oldPosition = testAsteroid.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        // Use the Assert class to test conditions.
        Assert.Less(testAsteroid.transform.position.y, oldPosition);
    }
    
    [UnityTest]
    public IEnumerator GameOverOccursOnAsteroidCollision()
    {
        GameObject testAsteroid = manager.SpawnAsteroid();
        testAsteroid.transform.position = manager.GetPlayer().transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(manager.gameObject.activeSelf);
    }

    [UnityTest]
    public IEnumerator NewGameRestartsGame()
    {
        manager.GameOver();
        manager.gameObject.SetActive(true);
        yield return null;
        Assert.IsTrue(manager.isActiveAndEnabled);
    }

    [UnityTest]
    public IEnumerator PlayerMoves()
    {
        PlayerControls controls = manager.GetPlayer();
        Vector2 oldPosition = controls.gameObject.transform.position;
        controls.Move(Vector2.left);
        yield return new WaitForSeconds(0.1f);
        Assert.Less(controls.gameObject.transform.position.x, oldPosition.x);
    }

    [UnityTest]
    public IEnumerator LaserMovesUp()
    {
        GameObject testLaser = manager.GetLaser();
        testLaser.SetActive(true);
        float oldPosition = testLaser.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(testLaser.transform.position.y, oldPosition);
    }

    [UnityTest]
    public IEnumerator LaserDestroysAsteroid()
    {
        GameObject testLaser = manager.GetLaser();
        testLaser.SetActive(true);

        GameObject testAsteroid = manager.SpawnAsteroid();

        testLaser.transform.position = testAsteroid.transform.position;

        yield return new WaitForSeconds(0.1f);

        Assert.IsFalse(testAsteroid.activeSelf && testLaser.activeSelf);
    }
}
