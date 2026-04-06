# eratohoK 游戏逻辑伪代码文档

## 概述

**eratohoK** 是一个基于东方Project的国盗SLG风调教模拟游戏。游戏包含两个主要阶段：
1. **据点フェイズ（拠点相位）** - 日常互动和角色培养
2. **戦略フェイズ（战略相位）** - 国家管理和战争

---

## 一、核心数据结构

### 1.1 角色数据 (Character)

```csharp
class Character {
    // 基本信息
    int ID;                     // 角色ID (从1开始)
    int No;                     // CSV编号
    string Name;                // 姓名
    string Nickname;            // 昵称
    int Gender;                 // 性别
    
    // 所属关系
    int Country;                // 所属势力ID
    int City;                   // 所在城市ID
    int PrisonerOf;             // 俘虏于哪个势力 (0=非俘虏)
    int SpecialState;           // 特殊状态 (0=正常，1=死亡，2=流浪等)
    
    // 基础属性 (BASE)
    int 体力;
    int 气力;
    int 怒气;
    int 哀伤;
    int 恐怖;
    int 愉悦;
    int 屈辱;
    int 堕落;
    int 反抗;
    int 服从;
    
    // 能力值 (ABL)
    int 欲望;
    int 性知识;
    int 主导度;
    int 受虐度;
    int 各种技能等级...
    
    // 素质/天赋 (TALENT)
    bool 处女;
    bool 童贞;
    bool 妊娠中;
    bool 危险日;
    bool 恋慕;
    bool 恋人;
    bool ツンデレ;
    bool 酒豪;
    bool 下户;
    // ... 更多天赋
    
    // 经验值 (EXP)
    int 各种经验值...
    
    // 好感度系统
    int 好感度;
    int 従属度;
    int 依存度;
    
    // 装备
    List<int> Equip;            // 当前装备列表
    
    // 技能
    List<Skill> Skills;         // 拥有的技能
    
    // 关系
    Dictionary<int, int> RelationLike;   // 对其他角色的好感
    Dictionary<int, int> RelationHate;   // 对其他角色的厌恶
    
    // 状态标记
    bool 调教参加Flag;
    bool 行动済み;
    int 行动不能状态;          // 0=正常，1=临月，2=育儿，3=受伤等
    
    // 性经验记录
    SexualExperience 初体验记录;
}
```

### 1.2 势力数据 (Country)

```csharp
class Country {
    int ID;                     // 势力ID
    int BossCharaID;            // 君主角色ID
    string Color;               // 势力颜色
    int 士兵数;
    int 经济规模;
    int 技术状态[科技树];
    bool 是AI控制;
    bool 已灭亡;
    int 无目标期限;             // 不主动攻击的回合数
}
```

### 1.3 城市数据 (City)

```csharp
class City {
    int ID;                     // 城市ID
    string Name;                // 城市名称
    int Owner;                  // 所属势力ID
    int Type;                   // 城市类型
    int 经济;                   // 经济值
    int 士兵;                   // 守备兵力
    int 防御;                   // 防御力
    int 开发度[建造物类型];     // 各种建筑的开发度
    List<int> Commanders;       // 驻守武将
}
```

### 1.4 部队数据 (Unit)

```csharp
class Unit {
    int CountryID;              // 所属势力
    int Index;                  // 部队索引 (0-9)
    int 士兵数;
    List<int> Commanders;       // 部队武将
    int Position;               // 当前位置
    int Target;                 // 攻击目标
}
```

### 1.5 全局状态 (GameState)

```csharp
class GameState {
    // 时间管理
    int Day;                    // 当前天数
    int Time;                   // 当前相位 (0=据点，1=战略)
    int ShopTime;               // 据点相位剩余行动次数
    
    // 游戏模式
    int 调教模式;               // 0=会面，1=育儿，2=俘虏调教，3=俘虏逆调教等
    bool ウフフFlag;            // 是否进入H场景
    int 主导权所有者;           // -1=成行，其他=角色ID
    
    // 玩家信息
    Character Master;           // 主人公
    int Money;                  // 资金
    Dictionary<string, int> Items; // 道具库存
    
    // 周回系统
    int 周回数;
    bool クリアFlag;
    
    // 外交
    int 外交调教Counter;
    int 调教要求Flag;
    
    // 配置选项
    Config Settings;
}
```

---

## 二、游戏主循环

### 2.1 启动流程

```
Main()
├── 显示标题画面 (SYSTEM_TITLE)
│   ├── 显示ASCII艺术标题
│   ├── 显示版本信息
│   └── 提供选项：新游戏/继续/自定义角色/帮助
│
├── [选择新游戏] → EVENTFIRST()
│   ├── INIT_NEWGAME()
│   │   ├── INIT_COMMON()
│   │   │   ├── 加载全局变量
│   │   │   ├── 初始化随机数
│   │   │   └── 清除目标列表
│   │   ├── NEWLOOP(周回数)
│   │   │   ├── NEWLOOP_RESET_VARS()
│   │   │   ├── 删除特殊角色
│   │   │   ├── STARTUP_SCENARIO()
│   │   │   │   ├── 选择剧本
│   │   │   │   ├── 选择势力
│   │   │   │   └── 选择/创建君主
│   │   │   ├── EXTRA_SETTING()
│   │   │   ├── SP_COUNTRY_SETTING()
│   │   │   └── 应用初始bonus
│   │   └── 设置初始状态
│   │
│   └── NEWLOOP()
│
└── [选择继续] → LOAD_GAME()
    └── RESTART
```

### 2.2 主循环结构

```
GameLoop()
├── while (!游戏结束)
│   │
│   ├── [据点相位] (TIME == 0)
│   │   ├── EVENT_MORNING()
│   │   │   ├── 显示日期和所在地
│   │   │   ├── 显示MASTER状态
│   │   │   └── 触发晨间事件
│   │   │
│   │   ├── SHOP_LOOP()
│   │   │   ├── while (SHOP_TIME > 0 && !捕虏中)
│   │   │   │   ├── 显示据点菜单
│   │   │   │   ├── 玩家选择行动:
│   │   │   │   │   ├── 训练 (TRAIN)
│   │   │   │   │   ├── 调教 (开始TRAIN模式)
│   │   │   │   │   ├── 探索领地
│   │   │   │   │   ├── 管理领地
│   │   │   │   │   ├── 外交
│   │   │   │   │   ├── 技能学习
│   │   │   │   │   ├── 购物
│   │   │   │   │   └── 休息
│   │   │   │   │
│   │   │   │   ├── 执行选择的行动
│   │   │   │   ├── SHOP_TIME--
│   │   │   │   └── 检查每日事件 (EVENT_DAILY)
│   │   │   │
│   │   │   └── SHOP_TIME耗尽或捕虏中 → 转入战略相位
│   │   │
│   │   └── TURNEND_LIFE()
│   │       ├── 计算据点收入
│   │   │   ├── 处理怀孕/分娩
│   │   │   ├── 处理角色成长
│   │   │   ├── 处理技能效果
│   │   │   └── TIME = 1
│   │
│   └── [战略相位] (TIME == 1)
│       ├── TURNEND_POLITICS()
│       │   ├── 显示战略地图
│       │   ├── 玩家回合:
│       │   │   ├── 移动部队
│       │   │   ├── 攻城
│       │   │   ├── 征兵
│       │   │   ├── 开发城市
│       │   │   ├── 外交交涉
│       │   │   └── 结束回合
│       │   │
│       │   ├── AI回合 (所有AI势力)
│       │   │   ├── SLG_AI_MAIN()
│       │   │   │   ├── 评估局势
│       │   │   │   ├── 决定战略方针
│       │   │   │   ├── 移动部队
│       │   │   │   ├── 发动攻击
│       │   │   │   └── 内政管理
│       │   │   │
│       │   │   └── 处理战斗结果
│       │   │
│       │   ├── 处理独立/起义事件
│       │   ├── 处理特殊势力事件
│       │   └── 检查胜利/失败条件
│       │
│       └── 回合结束
│           ├── DAY++
│           ├── TIME = 0
│           ├── SHOP_TIME = CALC_SHOP_TIME()
│           └── 检查外交调教请求
│
└── [游戏结束] → ENDING
```

---

## 三、调教系统 (TRAIN Mode)

### 3.1 调教启动

```
START_TRAIN(调教模式，参与者列表，目标列表)
├── EVENTTRAIN()
│   ├── 初始化调教环境
│   │   ├── 清空MPLY (玩家列表)
│   │   ├── 清空MTAR (目标列表)
│   │   ├── 添加参与者到MPLY
│   │   └── 添加目标到MTAR
│   │
│   ├── 设置调教参数
│   │   ├── TFLAG:56 = 调教时间长度
│   │   ├── FLAG:主导权所有者 = -1 (成行)
│   │   └── FLAG:ウフフFlag = false
│   │
│   ├── 初始化装备
│   │   └── INIT_EQUIP()
│   │
│   ├── 处理特殊起始状态
│   │   ├── 醉酒状态 (根据种族/天赋)
│   │   ├── 缚り状态 (逆调教时)
│   │   └── 润滑/欲情MAX (特殊势力调教)
│   │
│   └── 初始化临时变量
│       └── SET_TMP_MPLY/MTAR()
│
└── TRAIN_LOOP()
```

### 3.2 调教主循环

```
TRAIN_LOOP()
├── while (调教时间 > 0)
│   │
│   ├── SHOW_COMMAND()
│   │   ├── CREATE_COMABLE_LIST()
│   │   │   ├── 遍历所有命令 (0-999)
│   │   │   │   ├── CHECK_COMABLE(命令ID)
│   │   │   │   │   ├── COM_ABLE{命令ID}()
│   │   │   │   │   │   ├── 检查基本条件
│   │   │   │   │   │   │   ├── 玩家/目标数量
│   │   │   │   │   │   │   ├── 身体可达性
│   │   │   │   │   │   │   ├── 装备冲突
│   │   │   │   │   │   │   └── 天赋/状态限制
│   │   │   │   │   │   │
│   │   │   │   │   │   └── 返回: 0=不可用，1=可用，2=冲突，3=持续命令
│   │   │   │   │   │
│   │   │   │   │   └── 标记可用命令
│   │   │   │   │
│   │   │   │   └── 过滤被禁用的命令类别
│   │   │   │
│   │   │   └── 生成COM_ABLE_FLAG数组
│   │   │
│   │   ├── 显示命令界面
│   │   │   ├── 显示玩家/目标列表
│   │   │   ├── 按类别分页显示命令
│   │   │   │   ├── 0=爱抚系
│   │   │   │   ├── 1=口系
│   │   │   │   ├── 2=V系
│   │   │   │   ├── 3=A系
│   │   │   │   ├── 4=双重插入
│   │   │   │   ├── 5=器具系
│   │   │   │   ├── 6=特殊
│   │   │   │   └── 7=日常
│   │   │   │
│   │   │   └── 提供选项:
│   │   │       ├── 选择命令
│   │   │       ├── 更换玩家/目标
│   │   │       ├── 自动执行
│   │   │       └── 结束调教
│   │   │
│   │   └── 等待玩家输入
│   │
│   ├── [玩家选择命令]
│   │   ├── 执行命令主程序
│   │   │   ├── COM{命令ID}()
│   │   │   │   ├── COM_ORDER_COMMON()
│   │   │   │   │   └── 处理命令顺序和优先权
│   │   │   │   │
│   │   │   │   ├── 计算人数补正
│   │   │   │   │
│   │   │   │   ├── 对每个玩家处理:
│   │   │   │   │   ├── 消耗体力
│   │   │   │   │   ├── 获得经验
│   │   │   │   │   ├── 计算SOURCE
│   │   │   │   │   │   ├── 奉仕
│   │   │   │   │   │   ├── 接触
│   │   │   │   │   │   ├── 性行动
│   │   │   │   │   │   └── 快感 (根据感官)
│   │   │   │   │   │
│   │   │   │   │   └── 设置TCVAR标志
│   │   │   │   │
│   │   │   │   ├── 对每个目标处理:
│   │   │   │   │   ├── 消耗体力
│   │   │   │   │   ├── 计算SOURCE
│   │   │   │   │   │   ├── 露出
│   │   │   │   │   │   ├── 接触
│   │   │   │   │   │   ├── 性行动
│   │   │   │   │   │   └── 快感 (C/M/V/A等)
│   │   │   │   │   │
│   │   │   │   │   └── 处理特殊效果
│   │   │   │   │       ├── 插入中性能下降
│   │   │   │   │       └── 其他状态影响
│   │   │   │   │
│   │   │   │   └── 处理追加效果
│   │   │   │       ├── 爱情SOURCE (如果主从关系)
│   │   │   │       ├── 优悦/屈从SOURCE
│   │   │   │       └── 特殊技能效果
│   │   │   │
│   │   │   ├── 显示命令执行文本
│   │   │   │   ├── TRYCALLFORM COM_MARK{命令ID}()
│   │   │   │   ├── TRYCALLFORM COM_MESS{命令ID}()
│   │   │   │   └── 口上系统介入
│   │   │   │       └── KOJO_{角色ID}_{命令ID}()
│   │   │   │
│   │   │   └── 处理命令后效果
│   │   │       ├── APPLY_SOURCE()
│   │   │       ├── UPDATE_EXP()
│   │   │       └── 检查高潮/射精
│   │   │
│   │   ├── 时间流逝
│   │   │   └── TFLAG:55++
│   │   │
│   │   └── 检查是否进入H场景
│   │       └── 如果达到条件 → FLAG:ウフフFlag = true
│   │
│   └── [时间耗尽或强制结束]
│       └── BREAK
│
└── AFTER_TRAIN()
    ├── EVENT_AFTER()
    │   ├── 结算本次调教
    │   ├── 处理感情变化
    │   ├── 处理技能升级
    │   ├── 处理怀孕判定
    │   └── 处理堕落/觉醒
    │
    └── 返回据点/战略相位
```

### 3.3 SOURCE系统

```
APPLY_SOURCE()
├── 对每个参与者:
│   ├── 根据SOURCE值计算实际影响
│   │   ├── 快感系 → 增加欲望/堕落
│   │   ├── 爱情系 → 增加好感/恋慕
│   │   ├── 屈辱系 → 增加屈从/抑郁
│   │   └── 痛苦系 → 增加恐怖/反抗
│   │
│   ├── 应用PALAM变化
│   │   ├── PALAM:快C/V/A/M = 快感积累
│   │   ├── PALAM:爱 = 爱情积累
│   │   ├── PALAM:怒/哀/怖 = 负面情绪
│   │   └── PALAM:耻/苦/乐 = 综合感受
│   │
│   └── 检查阈值触发
│       ├── 高潮判定
│       ├── 精神崩溃
│       └── 觉醒/堕落
│
└── 更新角色状态
```

### 3.4 命令示例结构

```csharp
// 命令：爱抚 (ID: 0)
class Command_Abu {
    GetName() {
        if (MTAR.Count >= 2) return "同时爱抚";
        if (MPLY.Count >= 2) return "一齐爱抚";
        return "爱抚";
    }
    
    IsAble() {
        // 基本条件
        if (MPLY.Count == 0) return false;
        if (MTAR.Count == 0 || MTAR.Count > MPLY.Count * 2) return false;
        
        // 身体可达性检查
        foreach (var player in MPLY) {
            foreach (var target in MTAR) {
                if (!CanReachBody(player, target)) 
                    return false;
            }
        }
        
        return true;
    }
    
    Execute() {
        // 人数补正
        var powerBonus = CalculatePowerBonus(MPLY.Count, MTAR.Count);
        
        // 玩家侧处理
        foreach (var player in MPLY) {
            player.BASE.体力 -= 100;
            player.EXP.性技经验 += Math.Max(MTAR.Count / 2 + 1, 1);
            
            player.SOURCE.奉仕 = CalcServe(player, 100);
            player.SOURCE.接触 = 100;
            player.SOURCE.性行动 = 90;
            
            if (MTAR.Contains(MASTER))
                player.SOURCE.爱情 += 50;
            
            player.SOURCE.优悦 += CalcInitiative(player, 100, 20);
        }
        
        // 目标侧处理
        foreach (var target in MTAR) {
            target.BASE.体力 -= 60;
            
            target.SOURCE.露出 = 100;
            target.SOURCE.接触 = 100;
            target.SOURCE.性行动 = 180;
            
            if (MPLY.Contains(MASTER))
                target.SOURCE.爱情 += 100;
            
            target.SOURCE.优悦 += CalcInitiative(target, 60, 0);
            
            // 计算快感
            foreach (var player in MPLY) {
                target.SOURCE.快C += CalcSense(player, target, 1200) * powerBonus;
            }
            
            // 插入中性能下降
            if (IsInsertSingle(target, "All"))
                target.SOURCE.快C *= 0.8;
        }
        
        // 特殊：1v1时追加接吻
        if (MPLY.Count == 1 && MTAR.Count == 1) {
            if (CanKiss(MPLY[0], MTAR[0])) {
                ApplyKissEffect(MPLY[0], MTAR[0]);
            }
        }
    }
}
```

---

## 四、SLG战略系统

### 4.1 城市管理

```
CITY_MANAGEMENT()
├── 显示城市列表
│   └── 对每个城市:
│       ├── 显示基本信息
│       │   ├── 名称/所属势力
│       │   ├── 经济/士兵/防御
│       │   └── 驻守武将
│       │
│       └── 提供操作选项:
│           ├── 开发
│           │   ├── 选择建筑类型
│           │   │   ├── 兵舍 (+士兵上限)
│           │   │   ├── 农田 (+经济)
│           │   │   ├── 防御设施 (+防御)
│           │   │   ├── 研究设施 (+科技)
│           │   │   └── 特殊建筑
│           │   │
│           │   └── 投入资金
│           │       └── CITY_DEVELOPMENT[建筑类型] += 投资额
│           │
│           ├── 征兵
│           │   ├── 计算征兵上限
│           │   │   └── Limit = (经济总和/10) + 兵舍*500 + 科技补正
│           │   │
│           │   └── 招募士兵
│           │       ├── CITY_士兵 += 招募数
│           │       └── MONEY -= 招募费用
│           │
│           └── 任命武将
│               └── 分配武将到城市
│
└── 更新城市状态
```

### 4.2 部队管理

```
UNIT_MANAGEMENT()
├── 显示部队列表
│   └── 对每个部队:
│       ├── 显示信息
│       │   ├── 所属势力
│       │   ├── 士兵数
│       │   ├── 指挥官列表
│       │   └── 当前位置/目标
│       │
│       └── 提供操作选项:
│           ├── 编成
│           │   ├── 选择最多5名武将
│           │   └── 分配士兵
│           │
│           ├── 移动
│           │   ├── 选择目标城市
│           │   └── UNIT_位置 = 目标城市
│           │
│           ├── 攻击
│           │   ├── 选择目标城市
│           │   └── UNIT_目标 = 目标城市
│           │
│           └── 解散
│               └── 士兵回归城市
│
└── 更新部队状态
```

### 4.3 战斗系统

```
COMBAT(攻击方部队，防守方城市)
├── 战前准备
│   ├── 计算双方战力
│   │   ├── 攻击方:
│   │   │   ├── 总士兵数
│   │   │   ├── 武将能力补正
│   │   │   │   └── 统率/武力影响
│   │   │   └── 士气补正
│   │   │
│   │   └── 防守方:
│   │       ├── 城市士兵
│   │       ├── 城市防御
│   │       ├── 武将能力补正
│   │       └── 地形补正
│   │
│   └── 显示战斗预览
│
├── 战斗回合
│   ├── while (战斗未结束)
│   │   ├── 攻击方行动
│   │   │   ├── 选择攻击目标
│   │   │   ├── 计算伤害
│   │   │   │   ├── 基础伤害 = 攻击力 * 随机波动
│   │   │   │   ├── 技能发动判定
│   │   │   │   └── 最终伤害 = 基础伤害 * 补正
│   │   │   │
│   │   │   └── 应用伤害
│   │   │
│   │   ├── 防守方反击
│   │   │   └── 同上
│   │   │
│   │   └── 检查结束条件
│   │       ├── 攻击方全灭 → 防守胜利
│   │       ├── 防守方全灭 → 攻击胜利
│   │       └── 回合数上限 → 平局
│   │
│   └── 显示战斗过程
│
├── 战后处理
│   ├── [攻击胜利]
│   │   ├── 城市易主
│   │   ├── 俘虏敌方武将
│   │   ├── 掠夺资源
│   │   └── 士兵损失
│   │
│   ├── [防守胜利]
│   │   ├── 击退敌军
│   │   ├── 可能俘虏敌将
│   │   └── 士兵损失
│   │
│   └── [平局]
│       └── 双方撤退
│
└── 更新地图状态
```

### 4.4 AI逻辑

```
SLG_AI_MAIN(势力ID)
├── 评估局势
│   ├── 计算自身实力
│   │   ├── 经济规模
│   │   ├── 军事力量
│   │   └── 领土大小
│   │
│   ├── 分析周边势力
│   │   ├── 威胁度评估
│   │   └── 可攻击目标筛选
│   │
│   └── 决定战略方针
│       ├── 扩张型
│       ├── 防守型
│       └── 发展型
│
├── 执行决策
│   ├── 内政阶段
│   │   ├── 投资经济落后城市
│   │   ├── 补充兵力不足城市
│   │   └── 研发科技
│   │
│   ├── 军事阶段
│   │   ├── 集结部队
│   │   ├── 选择攻击目标
│   │   │   ├── 优先攻击弱小势力
│   │   │   ├── 优先攻击接壤城市
│   │   │   └── 考虑外交关系
│   │   │
│   │   └── 发动攻击
│   │
│   └── 外交阶段
│       ├── 结盟请求
│       ├── 停战提议
│       └── 臣服要求
│
└── 更新AI状态
```

### 4.5 外交系统

```
DIPLOMACY(我方势力，对方势力)
├── 选择外交行动
│   ├── 同盟提案
│   │   ├── 计算成功率
│   │   │   ├── 好感度影响
│   │   │   ├── 实力差距影响
│   │   │   └── 外交信誉影响
│   │   │
│   │   └── 成功 → 建立同盟
│   │
│   ├── 停战提案
│   │   └── 成功 → 停止交战X回合
│   │
│   ├── 臣服要求
│   │   └── 成功 → 对方成为附属国
│   │
│   ├── 割让要求
│   │   └── 成功 → 获得指定城市
│   │
│   ├── 调教要求 (特色系统)
│   │   ├── 要求对方派遣角色进行调教
│   │   └── 成功 → 开启外交调教事件
│   │
│   └── 宣战布告
│       └── 进入交战状态
│
└── 更新外交关系
```

---

## 五、每日事件系统 (Daily Events)

### 5.1 事件触发流程

```
EVENT_DAILY()
├── 检查是否可以触发
│   └── IS_DAILY_EVENT_HAPPEN(MASTER)
│       └── 非特殊状态 && 非俘虏 && 有所属势力
│
├── 计算衍生参数
│   └── DAILY_DERIVATION()
│       └── 根据角色状态计算临时参数
│
├── 事件选择
│   ├── 获取可用事件列表
│   ├── Fisher-Yates洗牌
│   │
│   └── 遍历事件:
│       ├── 检查配置是否禁用
│       │
│       ├── 发生率判定
│       │   └── IF (事件几率 * 发生倍率 <= RAND(1000)) → 跳过
│       │
│       ├── 特殊条件检查
│       │   └── 流浪中专用事件检查
│       │
│       ├── 发生决定函数
│       │   └── EVENT_DAILY_{事件名}_DECISION()
│       │
│       ├── 选择目标
│       │   └── EVENT_DAILY_{事件名}_SETTARGET()
│       │       ├── 随机选择角色
│       │       ├── 随机选择城市
│       │       └── 随机选择势力
│       │
│       └── 执行事件
│           ├── 显示事件名称
│           └── EVENT_DAILY_{事件名}()
│               ├── 显示事件文本
│               ├── 提供选项
│               ├── 根据选择分支
│               └── 更新角色状态
│
└── 返回是否发生事件
```

### 5.2 事件模板

```csharp
// 事件模板示例
class DailyEvent_TedemoNoNaiNichijou {
    // 发生率 (1000分率)
    GetRate() => 25;  // 2.5%
    
    // 发生条件
    IsDecision() {
        if (DAY < 5) return false;
        if (!HAS_PENIS(MASTER)) return false;
        return true;
    }
    
    // 目标选择
    SetTarget() {
        var candidates = [];
        foreach (var chara in AllCharacters) {
            if (chara.IsFemale && 
                chara.Country == MASTER.Country && 
                !chara.IsPrisoner &&
                !chara.IsAnimal &&
                chara.Acquaintance > 0) {
                candidates.Add(chara);
            }
        }
        
        if (candidates.Count < 11) return false;
        
        DAILY_TARGET = candidates;
        return true;
    }
    
    // 事件本体
    Execute() {
        var target = DAILY_TARGET[RAND(DAILY_TARGET.Count)];
        
        // 确保有面识
        if (target.Acquaintance == 0)
            target.Acquaintance = 1;
        
        // 好感度检查
        if (target.Favorability < 0) {
            Print($"{target.Name}避开了你");
            return;
        }
        
        // 随机分支
        switch (RAND(20)) {
            case 0: // 发型变化
                HandleHairStyleEvent(target);
                break;
            case 1: // 打盹
                HandleNapEvent(target);
                break;
            case 2: // 马戏团门票
                HandleTicketEvent(target);
                break;
            // ... 其他分支
        }
    }
    
    HandleHairStyleEvent(target) {
        Print($"遇到了{target.Name}，她换了新发型");
        var choice = Ask("夸奖合适", "说原来的好", "摸头");
        
        switch (choice) {
            case 0:
                Print("夸奖后她笑了");
                target.Favorability += 50;
                break;
            case 1:
                Print("她说原来的是吗，然后回去了");
                break;
            case 2:
                if (target.Favorability + RAND(300) >= 1000) {
                    Print("摸头后她很高兴");
                    target.Favorability += 80;
                } else {
                    Print("被她轻轻推开了手");
                }
                break;
        }
    }
}
```

---

## 六、技能系统 (Skills)

### 6.1 技能结构

```csharp
class Skill {
    int ID;
    string Name;
    string Description;
    int MaxLevel;
    
    // 被动效果
    bool HasPassive(int level);
    void OnTurnEnd(Character owner, int level);
    void OnDamageReceived(Character owner, ref int damage, int level);
    // ... 其他被动触发点
    
    // 主动效果
    bool CanActivate(Character owner, int level);
    void Activate(Character owner, int level);
    
    // 获取方式
    AcquisitionMethod Method;
}
```

### 6.2 技能示例

```csharp
// 技能：超成长力
class Skill_SuperGrowth : Skill {
    public Skill_SuperGrowth() {
        ID = 0;
        Name = "超成长力";
        Description = "回合结束时获得经验值，能力成长变快";
        MaxLevel = 5;
    }
    
    HasPassive(level) => true;
    
    OnTurnEnd(owner, level) {
        // 每回合获得额外经验
        var expBonus = level * 10;
        owner.EXP.全经验 += expBonus;
        
        // 成长率提升
        owner.GrowthRateMultiplier += (level * 0.1);
    }
}

// 技能：治疗
class Skill_Healing : Skill {
    public Skill_Healing() {
        ID = 2;
        Name = "治疗";
        Description = "可以恢复自己或他人的体力";
        MaxLevel = 3;
    }
    
    CanActivate(owner, level) {
        return owner.BASE.气力 >= 100;
    }
    
    Activate(owner, level) {
        var target = SelectTarget();
        var healAmount = 500 * level;
        
        target.BASE.体力 += healAmount;
        owner.BASE.气力 -= 100;
        
        Print($"{owner.Name}使用了治疗，恢复了{healAmount}体力");
    }
}
```

### 6.3 技能发动时机

```
SKILL_TIMING_TRIGGERS
├── 回合开始 (TURN_START)
├── 回合结束 (TURN_END)
├── 战斗开始 (BATTLE_START)
├── 战斗结束 (BATTLE_END)
├── 受到伤害时 (DAMAGE_RECEIVED)
├── 造成伤害时 (DEAL_DAMAGE)
├── 命令执行前 (COMMAND_BEFORE)
├── 命令执行后 (COMMAND_AFTER)
├── 高潮时 (ORGASM)
├── 怀孕时 (PREGNANCY)
├── 分娩时 (CHILDBIRTH)
└── 升级时 (LEVEL_UP)
```

---

## 七、口上系统 (Dialogue System)

### 7.1 口上触发机制

```
KOJO_SYSTEM(说话者，听话者，情境)
├── 确定口上模式
│   ├── 通常口上
│   ├── 调教口上
│   ├── 日常口上
│   └── 特殊事件口上
│
├── 搜索口上文件
│   ├── 优先：角色专属口上
│   │   └── /口上/{角色ID}_{角色名}/
│   │
│   ├── 次选：通用口上
│   │   └── /口上/COMMON/
│   │
│   └── 后备：默认文本
│
├── 构建口上键值
│   ├── 格式：KOJO_{角色ID}_{情境ID}_{子情境}
│   │
│   └── 示例:
│       ├── KOJO_77_000_1 (白莲_爱抚_通常)
│       ├── KOJO_77_001_2 (白莲_口交_连续)
│       └── KOJO_77_TRAIN_START (白莲_调教开始)
│
├── 调用口上函数
│   ├── 如果存在专属函数 → 执行
│   ├── 否则 → 使用默认文本
│   │
│   └── 口上函数内部:
│       ├── 根据状态分支
│       │   ├── 好感度高低
│       │   ├── 従属度高低
│       │   ├── 是否恋慕
│       │   ├── 是否初次
│       │   └── 其他状态
│       │
│       ├── 插入变量
│       │   ├── %ANAME(角色)% → 角色名
│       │   ├── %CNAME(身体部位)% → 身体部位名
│       │   └── 数值/状态
│       │
│       └── 返回文本
│
└── 显示口上文本
```

### 7.2 现代化口上设计 (用于AI生成)

```csharp
// 传统口上 (硬编码)
@KOJO_77_000_1
IF CFLAG:77:好感度 >= 1000
        RESULTS = "%ANAME(77)%「啊啦，真是温柔呢」"
ELSEIF CFLAG:77:好感度 >= 500
        RESULTS = "%ANAME(77)%「...谢谢」"
ELSE
        RESULTS = "%ANAME(77)%「请不要这样...」"
ENDIF

// 现代化设计 (语义标签 + AI生成)
class KojoTemplate {
    // 元数据
    string CharacterID = "77";
    string CharacterName = "白莲";
    string Situation = "Abuse";  // 爱抚
    string SubSituation = "Normal";
    
    // 语义标签 (用于AI理解情境)
    List<string> Tags = new() {
        "gentle_touch",
        "intimate_moment",
        "player_initiated"
    };
    
    // 状态条件
    Dictionary<string, object> Conditions = new() {
        { "favorability_high", ">=1000" },
        { "favorability_mid", "500-999" },
        { "favorability_low", "<500" },
        { "is_first_time", "false" },
        { "has_love", "any" }
    };
    
    // AI生成提示词模板
    string AIPromptTemplate = @"
角色：{CharacterName}
性格：温柔、包容、有些神秘
情境：正在被{PlayerName}爱抚
关系状态：{RelationshipStatus}
情感状态：{EmotionalState}

请生成一句符合角色性格的台词，表达她此刻的感受和反应。
要求：
- 体现角色特点
- 符合当前亲密度
- 自然流畅
- 长度适中
";
    
    // 运行时生成
    string GenerateDialogue(GameState state) {
        var context = BuildContext(state);
        var prompt = AIPromptTemplate
            .Replace("{CharacterName}", CharacterName)
            .Replace("{PlayerName}", state.Master.Name)
            .Replace("{RelationshipStatus}", GetRelationshipDescription(state))
            .Replace("{EmotionalState}", GetEmotionalDescription(state));
        
        // 调用小模型生成
        return AIModel.Generate(prompt, temperature: 0.7);
    }
    
    // 缓存常用对话 (减少AI调用)
    Dictionary<string, string> CachedDialogues = new() {
        { "first_abuse_surprised", "「呀...！请、请不要突然...」" },
        { "high_favor_loved", "「呵呵...你的触碰，很温暖呢」" },
        { "low_favor_resist", "「还、还没有到那种程度...」" }
        // ... 预生成常用对话
    };
}
```

### 7.3 语义合成策略

```csharp
class DialogueSynthesizer {
    // 语义元素
    enum EmotionType {
        Joy, Sadness, Anger, Fear, 
        Surprise, Disgust, Love, Shame
    }
    
    enum IntimacyLevel {
        Stranger, Acquaintance, Friend, 
        CloseFriend, Lover, Devoted
    }
    
    enum ActionIntensity {
        Gentle, Normal, Rough, Extreme
    }
    
    // 合成对话
    string Synthesize(
        Character speaker,
        Character listener,
        string action,
        EmotionType emotion,
        IntimacyLevel intimacy,
        ActionIntensity intensity
    ) {
        // 1. 确定基础模板
        var template = SelectTemplate(action, emotion);
        
        // 2. 根据亲密度调整语气
        template = AdjustForIntimacy(template, intimacy);
        
        // 3. 根据强度调整措辞
        template = AdjustForIntensity(template, intensity);
        
        // 4. 注入角色特征
        template = InjectCharacterTraits(template, speaker);
        
        // 5. 可选：AI润色
        if (UseAIRefinement) {
            template = AIRefine(template, speaker, listener);
        }
        
        return template;
    }
    
    // 模板选择
    string SelectTemplate(string action, EmotionType emotion) {
        // 从模板库中选择
        // 示例：
        // action="abuse", emotion=joy → "享受型"模板
        // action="abuse", emotion=fear → "抗拒型"模板
    }
    
    // AI润色 (小模型)
    string AIRefine(string baseText, Character speaker, Character listener) {
        var prompt = $@"
基础台词：{baseText}
角色：{speaker.Name} ({speaker.PersonalityTags})
对象：{listener.Name}
关系：{GetRelationship(speaker, listener)}

请在保持原意的基础上，让台词更符合角色性格。
只输出润色后的台词。
";
        return SmallAI.Generate(prompt);
    }
}
```

---

## 八、怀孕与育儿系统

### 8.1 怀孕流程

```
PREGNANCY_SYSTEM()
├── 怀孕判定
│   ├── 每次体内射精后
│   │   ├── 检查是否在危险日
│   │   ├── 检查避孕措施
│   │   └── 概率判定
│   │       └── P = 基础率 * 危险日补正 * 技能补正
│   │
│   └── 确认怀孕
│       ├── TALENT:妊娠 = true
│       ├── 计算预产期
│       └── 通知玩家
│
├── 孕期管理
│   ├── 每月变化
│   │   ├── 体型变化
│   │   ├── 能力变化
│   │   └── 状态变化
│   │
│   ├── 临月
│   │   ├── 行动不能
│   │   └── 准备分娩
│   │
│   └── 随机事件
│       ├── 孕吐
│       ├── 胎动
│       └── 特殊对话
│
└── 分娩
    ├── 计算分娩结果
    │   ├── 单胎/多胎
    │   ├── 性别
    │   └── 资质
    │
    ├── 生成婴儿角色
    │   ├── 继承父母特征
    │   ├── 随机变异
    │   └── 设定成长参数
    │
    └── 产后状态
        ├── 哺乳期
        └── 育儿模式开启
```

### 8.2 育儿系统

```
CHILD_RAISING()
├── 育儿模式
│   ├── 时间消耗
│   │   └── 每次育儿占用5单位时间
│   │
│   ├── 育儿活动
│   │   ├── 喂奶
│   │   ├── 换尿布
│   │   ├── 玩耍
│   │   └── 教育
│   │
│   └── 孩子成长
│       ├── 成长度累积
│       ├── 阶段性变化
│       │   ├── 婴儿
│       │   ├── 幼儿
│       │   ├── 儿童
│       │   └── 成人 (可加入队伍)
│       │
│       └── 能力发展
│           └── 根据教育和遗传
│
└── 亲子关系
    ├── 亲情度
    ├── 性格形成
    └── 未来职业倾向
```

---

## 九、配置与自定义系统

### 9.1 配置项分类

```
CONFIG_SYSTEM
├── 游戏难度
│   ├── 敌人强度
│   ├── 资源获取率
│   └── 事件发生率
│
├── 显示设置
│   ├── 文本速度
│   ├── 自动播放间隔
│   ├── 颜色主题
│   └── UI布局
│
├── 内容过滤
│   ├── 启用/禁用命令类别
│   ├── 启用/禁用事件类型
│   ├── 敏感内容屏蔽
│   └── 年龄分级
│
├── 自动化设置
│   ├── 自动选择命令
│   ├── 自动推进对话
│   └── 批量处理
│
└── 调试功能
    ├── 无敌模式
    ├── 无限资源
    ├── 即时事件触发
    └── 数据导出
```

### 9.2 自定义角色

```
CUSTOM_CHARACTER_CREATION()
├── 基础设定
│   ├── 姓名
│   ├── 性别
│   ├── 外观 (发色/瞳色等)
│   └── 声音 (如果有)
│
├── 能力分配
│   ├── 属性点分配
│   ├── 初始技能选择
│   └── 天赋选择
│
├── 背景设定
│   ├── 出身势力
│   ├── 初始关系
│   └── 个人历史
│
└── 保存/加载
    ├── 保存到文件
    ├── 从文件加载
    └── 分享代码
```

---

## 十、存档与读档系统

### 10.1 存档结构

```csharp
class SaveData {
    // 元数据
    string SaveVersion;
    DateTime SaveTime;
    int PlayTime;
    int ClearCount;
    
    // 游戏状态
    GameState State;
    
    // 角色数据
    List<Character> Characters;
    
    // 世界状态
    List<Country> Countries;
    List<City> Cities;
    List<Unit> Units;
    
    // 关系网络
    RelationshipMap Relations;
    
    // 事件进度
    EventFlags EventFlags;
    DailyEventVars DVars;
    
    // 成就/统计
    Statistics Stats;
    
    // 序列化
    byte[] Serialize() { ... }
    static SaveData Deserialize(byte[] data) { ... }
}
```

### 10.2 快速存档/读档

```
QUICK_SAVE_LOAD()
├── 快速存档槽位 (3个)
├── 普通存档槽位 (20个)
├── 周回继承存档 (1个)
│
└── 自动存档
    ├── 每日开始时
    ├── 重大事件前后
    └── 战斗前后
```

---

## 十一、数据统计与成就

### 11.1 统计数据

```csharp
class Statistics {
    // 游戏进度
    int TotalPlayTime;
    int DaysPassed;
    int TurnsPlayed;
    
    // 战斗统计
    int BattlesWon;
    int BattlesLost;
    int EnemiesDefeated;
    int Casualties;
    
    // 角色统计
    int CharactersRecruited;
    int CharactersLoved;
    int ChildrenBorn;
    
    // 调教统计
    int TrainingSessions;
    int CommandsUsed;
    int OrgasmsReached;
    
    // 收集要素
    int EventsSeen;
    int EndingsUnlocked;
    int SkillsMastered;
    
    // 排行榜数据
    int HighestScore;
    FastestClearTime;
    LargestArmySize;
}
```

### 11.2 成就系统

```csharp
class AchievementSystem {
    List<Achievement> Achievements;
    
    class Achievement {
        string ID;
        string Name;
        string Description;
        AchievementCondition Condition;
        bool IsUnlocked;
        DateTime UnlockTime;
    }
    
    CheckAchievements(GameState state) {
        foreach (var achievement in Achievements) {
            if (!achievement.IsUnlocked && 
                achievement.Condition.Check(state)) {
                achievement.IsUnlocked = true;
                achievement.UnlockTime = DateTime.Now;
                NotifyUnlock(achievement);
            }
        }
    }
}
```

---

## 十二、扩展性与Mod支持

### 12.1 Mod架构

```
MOD_SYSTEM
├── Mod加载顺序
│   ├── 基础游戏
│   ├── 官方扩展
│   └── 用户Mod (按优先级)
│
├── Mod内容类型
│   ├── 新角色
│   ├── 新事件
│   ├── 新技能
│   ├── 新命令
│   ├── 新势力
│   └── UI修改
│
├── Mod兼容性
│   ├── API版本检查
│   ├── 依赖管理
│   └── 冲突检测
│
└── Mod分发
    ├── Mod包格式
    ├── 安装向导
    └── 在线仓库
```

### 12.2 脚本系统

```csharp
// 事件脚本示例
class EventScript {
    string EventID;
    List<EventStep> Steps;
    
    class EventStep {
        string Type;  // "DIALOGUE", "CHOICE", "EFFECT", etc.
        Dictionary<string, object> Parameters;
        List<string> NextSteps;  // 分支
        
        Execute(GameState state) {
            switch (Type) {
                case "DIALOGUE":
                    ShowDialogue(Parameters["speaker"], 
                                Parameters["text"]);
                    break;
                case "CHOICE":
                    var result = ShowChoice(Parameters["options"]);
                    JumpTo(NextSteps[result]);
                    break;
                case "EFFECT":
                    ApplyEffect(Parameters["effect"], 
                               Parameters["target"]);
                    break;
            }
        }
    }
}
```

---

## 十三、性能优化建议

### 13.1 数据管理

```csharp
// 使用对象池减少GC
class CharacterPool {
    Queue<Character> pool = new();
    
    Character Get() {
        if (pool.Count > 0) {
            var c = pool.Dequeue();
            c.Reset();
            return c;
        }
        return new Character();
    }
    
    void Return(Character c) {
        c.Cleanup();
        pool.Enqueue(c);
    }
}

// 使用增量更新减少计算
class DirtyFlagSystem {
    bool isDirty;
    
    void MarkDirty() => isDirty = true;
    
    void UpdateIfNeeded() {
        if (isDirty) {
            Recalculate();
            isDirty = false;
        }
    }
}
```

### 13.2 渲染优化

```csharp
// 视锥剔除
class ViewCulling {
    Rect visibleArea;
    
    List<GameObject> GetVisibleObjects() {
        return objects.Where(o => 
            visibleArea.Intersects(o.Bounds)
        ).ToList();
    }
}

// 分层渲染
enum RenderLayer {
    Background,
    Terrain,
    Buildings,
    Units,
    UI,
    Effects
}
```

---

## 十四、总结

### 核心系统依赖关系

```
GameState
├── CharacterManager
│   ├── StatusSystem
│   ├── RelationshipSystem
│   └── SkillSystem
│
├── WorldManager
│   ├── CountryManager
│   ├── CityManager
│   └── UnitManager
│
├── EventSystem
│   ├── DailyEventSystem
│   ├── StoryEventSystem
│   └── BattleEventSystem
│
├── TrainingSystem
│   ├── CommandSystem
│   ├── SourceSystem
│   └── KojoSystem
│
├── DiplomacySystem
│   ├── AISystem
│   └── NegotiationSystem
│
└── SaveLoadSystem
    ├── Serialization
    └── VersionControl
```

### 开发优先级建议

1. **第一阶段**: 核心框架
   - 数据结构定义
   - 基本游戏循环
   - 存档系统

2. **第二阶段**: 据点相位
   - 角色管理系统
   - 每日事件框架
   - 基础调教系统

3. **第三阶段**: 战略相位
   - 城市/势力管理
   - 基础AI
   - 战斗系统

4. **第四阶段**: 内容填充
   - 大量事件
   - 技能系统
   - 口上系统

5. **第五阶段**: 优化与扩展
   - 性能优化
   - Mod支持
   - AI对话集成

---

## 附录：关键常量定义

```csharp
// 游戏模式
enum GameMode {
    Title = 0,
    Shop = 1,
    Strategy = 2,
    Training = 3
}

// 调教模式
enum TrainingMode {
    Meet = 0,           // 会面
    ChildCare = 1,      // 育儿
    Prisoner = 2,       // 俘虏调教
    PrisonerReverse = 3,// 俘虏逆调教
    SpecialReverse = 4, // 特殊逆调教
    Comfort = 5         // 慰安
}

// 行动不能状态
enum UnableState {
    Normal = 0,
    PregnantFull = 1,   // 临月
    ChildCare = 2,      // 育儿
    Injured = 3,        // 受伤
    Child = 4           // 小孩
}

// 命令类别
enum CommandCategory {
    Caress = 0,     // 爱抚
    Oral = 1,       // 口
    Vaginal = 2,    // V
    Anal = 3,       // A
    Double = 4,     // 双重
    Tool = 5,       // 器具
    Special = 6,    // 特殊
    Daily = 7       // 日常
}

// 势力AI类型
enum AIType {
    Aggressive = 0,     // 扩张型
    Defensive = 1,      // 防守型
    Development = 2,    // 发展型
    Balanced = 3        // 平衡型
}
```

---

*文档版本：1.0*
*最后更新：2024*
*适用于：C#重制版开发参考*
